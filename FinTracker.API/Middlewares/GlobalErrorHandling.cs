using FinTracker.Application.Resources;
using FinTracker.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace FinTracker.API.Middlewares;

public class GlobalErrorHandling
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public GlobalErrorHandling(RequestDelegate next, ILoggerFactory logger)
    {
        _next = next;
        _logger = logger.CreateLogger("LogError");
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleErrorAsync(httpContext, ex);
        }
    }

    private async Task HandleErrorAsync(HttpContext httpContext, Exception exception)
    {
        ErrorResponse errorResponse = new();

        _logger.LogError($"Error Message: {exception.Message}");
        _logger.LogError($"Inner Error Message: {exception.InnerException?.Message}");
        _logger.LogError($"Error Stack: {exception.StackTrace}");

        httpContext.Response.ContentType = "application/json";

        switch (exception)
        {
            case UserException ex:
                    errorResponse.Message = ex.Message;

                    httpContext.Response.StatusCode = (int)ex.Code;
                    await httpContext.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
                
                break;

            default:
                errorResponse.Message = ApplicationMessages.DefaultError;

                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
                break;
        }


    }
}
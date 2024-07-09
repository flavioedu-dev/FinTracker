using FinTracker.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
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
        catch (UserException ex)
        {
            await HandleErrorAsync(httpContext, ex);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error Message: {ex.Message}");
            _logger.LogError($"Error Stack: {ex.StackTrace}");

            ErrorResponse errorResponse = new()
            {
                Sucess = false,
                Message = "Erro no sistema, tente novamente."
            };

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        }


    }

    private async Task HandleErrorAsync(HttpContext httpContext, UserException exception)
    {
        ErrorResponse errorResponse = new();
        errorResponse.Sucess = false;

        _logger.LogError($"Error Message: {exception.Message}");
        _logger.LogError($"Error Stack: {exception.StackTrace}");

        httpContext.Response.ContentType = "application/json";

        if (exception.Code is HttpStatusCode.NotFound)
        {
            errorResponse.Message = "Usuário não encontrado.";

            httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        }
    }
}
namespace FinTracker.API.Middlewares;

public static class MiddlewaresExtensions
{
    public static IApplicationBuilder UseGlobalErrorHandling(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<GlobalErrorHandling>();
    }
}
using Microsoft.Extensions.Options;
using mvc.Configurations.Middleware;

namespace mvc.Configurations.Extensions;

public enum ExceptionHandlingType
{
    CustomMiddleware,
    ErrorController
}

public class GlobalErrorHandlingOptions
{
    public ExceptionHandlingType? ExceptionHandlingType { get; set; }
}

public static class WebApplicationUseGlobalErrorHandlerExtension
{
    public static WebApplication UseGlobalErrorHandler(this WebApplication app)
    {
        var options = app.Services.GetService<IOptions<GlobalErrorHandlingOptions>>();

        if (options?.Value?.ExceptionHandlingType is null)
        {
            return app;
        }

        switch (options.Value.ExceptionHandlingType)
        {
            case ExceptionHandlingType.CustomMiddleware:
                app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
                break;
            case ExceptionHandlingType.ErrorController:
                var isDevelopment = app.Environment.IsDevelopment();
                app.UseExceptionHandler(isDevelopment ? "/error-development" : "/error");
                break;
        }

        return app;
    }
}
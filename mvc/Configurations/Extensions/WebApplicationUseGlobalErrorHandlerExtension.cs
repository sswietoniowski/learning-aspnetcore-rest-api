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
        ExceptionHandlingType? exceptionHandlingType = options?.Value?.ExceptionHandlingType;

        if (exceptionHandlingType is null)
        {
            return app;
        }

        switch (exceptionHandlingType)
        {
            case ExceptionHandlingType.CustomMiddleware:
                app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
                break;
            case ExceptionHandlingType.ErrorController:
                app.UseExceptionHandler("/Error");
                break;
        }

        return app;
    }
}
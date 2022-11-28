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
    private static ExceptionHandlingType? ExceptionHandlingType =>
    {
        var options = app.Services.GetService<IOptions<GlobalErrorHandlingOptions>>();
        return options?.Value?.ExceptionHandlingType;
    }

    public static WebApplication UseGlobalErrorHandler(this WebApplication app)
    {
        switch (ExceptionHandlingType)
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
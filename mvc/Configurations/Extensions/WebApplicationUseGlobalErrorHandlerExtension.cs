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
    private static ExceptionHandlingType? GetExceptionHandlingType(this WebApplication webApplication)
    {
        return webApplication.Services.GetService<IOptions<GlobalErrorHandlingOptions>>()
            ?.Value.ExceptionHandlingType;
    }

    public static WebApplication UseGlobalErrorHandler(this WebApplication app)
    {
        switch (app.GetExceptionHandlingType())
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
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
    public static void UseGlobalErrorHandler(this WebApplication app)
    {
        var options = app.Services.GetService<IOptions<GlobalErrorHandlingOptions>>();

        if (options?.Value?.ExceptionHandlingType is null)
        {
            return;
        }

        switch (options.Value.ExceptionHandlingType)
        {
            case ExceptionHandlingType.CustomMiddleware:
                app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
                break;
            case ExceptionHandlingType.ErrorController:
                app.UseExceptionHandler(app.Environment.IsDevelopment() ? "/error-development" : "/error");
                break;
        }
    }
}
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

public static class ApplicationBuilderUseGlobalErrorHandlerExtension
{
    public static void UseGlobalErrorHandler(this IApplicationBuilder app)
    {
        var options = app.ApplicationServices.GetService<IOptions<GlobalErrorHandlingOptions>>();

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
                app.UseExceptionHandler(
                    app.ApplicationServices.GetService<IHostEnvironment>()?.IsDevelopment() == true
                        ? "/error-development"
                        : "/error");
                break;
        }
    }
}
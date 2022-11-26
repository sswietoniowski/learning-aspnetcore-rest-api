using mvc.Configurations.Middleware;

namespace mvc.Configurations.Extensions;

public static class ApplicationBuilderUseGlobalErrorHandlerExtension
{
    public static void UseGlobalErrorHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
    }
}
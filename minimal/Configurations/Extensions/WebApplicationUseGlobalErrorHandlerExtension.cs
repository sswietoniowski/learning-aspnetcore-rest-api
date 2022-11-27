using minimal.Configurations.Middleware;

namespace minimal.Configurations.Extensions;

public static class WebApplicationUseGlobalErrorHandlerExtension
{
    public static void UseGlobalErrorHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
    }
}
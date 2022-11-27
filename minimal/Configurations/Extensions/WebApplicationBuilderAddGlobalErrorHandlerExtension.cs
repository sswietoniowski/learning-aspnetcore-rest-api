using minimal.Configurations.Middleware;

namespace minimal.Configurations.Extensions;

public static class WebApplicationBuilderAddGlobalErrorHandlerExtension
{
    public static WebApplicationBuilder AddGlobalErrorHandler(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();

        return builder;
    }
}
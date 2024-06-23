using mvc.Configurations.Middleware;

namespace mvc.Configurations.Extensions;

public static class WebApplicationBuilderAddGlobalErrorHandlerExtension
{
    public static WebApplicationBuilder AddGlobalErrorHandler(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<GlobalErrorHandlingOptions>(
            builder.Configuration.GetSection("GlobalErrorHandlingOptions"));

        builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();

        return builder;
    }
}
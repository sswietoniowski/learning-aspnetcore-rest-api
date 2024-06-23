using Microsoft.OpenApi.Models;

namespace minimal.Configurations.Extensions;

public static class WebApplicationBuilderAddSwaggerExtension
{
    public static WebApplicationBuilder AddSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "minimal", Version = "v1" });
        });

        return builder;
    }
}
using Microsoft.OpenApi.Models;

namespace mvc.Configurations.Extensions;

public static class WebApplicationBuilderConfigureSwaggerExtension
{
    public static WebApplicationBuilder ConfigureSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "mvc", Version = "v1" });
        });

        return builder;
    }
}
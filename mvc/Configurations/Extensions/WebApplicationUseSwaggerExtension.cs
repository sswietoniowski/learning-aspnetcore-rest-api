using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace mvc.Configurations.Extensions;

public static class WebApplicationUseSwaggerExtension
{
    public static WebApplication UseSwagger(this WebApplication app)
    {
        var isDevelopment = app.Environment.IsDevelopment();

        if (!isDevelopment)
        {
            return app;
        }

        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

        SwaggerBuilderExtensions.UseSwagger(app);
        app.UseSwaggerUI(options =>
        {
            string swaggerJsonBasePath = string.IsNullOrWhiteSpace(options.RoutePrefix) ? "." : "..";

            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint(
                    $"{swaggerJsonBasePath}/swagger/{description.GroupName}/swagger.json",
                    description.GroupName.ToUpperInvariant());
            }
        });

        return app;
    }
}
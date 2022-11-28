namespace mvc.Configurations.Extensions;

public static class WebApplicationUseSwaggerExtension
{
    private static bool IsDevelopment(this WebApplication app) =>
        app.Environment.IsDevelopment();

    public static WebApplication UseSwagger(this WebApplication app)
    {
        if (app.IsDevelopment())
        {
            SwaggerBuilderExtensions.UseSwagger(app);
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "mvc v1"));
        }

        return app;
    }
}
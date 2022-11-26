namespace mvc.Configurations.Extensions;

public static class WebApplicationUseSwaggerExtension
{
    public static WebApplication UseSwagger(this WebApplication app)
    {
        var isDevelopment = app.Environment.IsDevelopment();

        if (isDevelopment)
        {
            SwaggerBuilderExtensions.UseSwagger(app);
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "mvc v1"));
        }

        return app;
    }
}
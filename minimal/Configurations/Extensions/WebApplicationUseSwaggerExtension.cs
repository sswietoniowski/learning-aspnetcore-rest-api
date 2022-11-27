﻿namespace minimal.Configurations.Extensions;

public static class WebApplicationUseSwaggerExtension
{
    public static WebApplication UseSwagger(this WebApplication app)
    {
        var isDevelopment = app.Environment.IsDevelopment();

        if (isDevelopment)
        {
            SwaggerBuilderExtensions.UseSwagger(app);
            app.MapSwagger();
            app.UseSwaggerUI();
        }

        return app;
    }
}
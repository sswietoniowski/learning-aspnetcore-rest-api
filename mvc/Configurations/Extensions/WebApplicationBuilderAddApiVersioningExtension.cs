using Microsoft.AspNetCore.Mvc;

namespace mvc.Configurations.Extensions;

public static class WebApplicationBuilderAddApiVersioningExtension
{
    public static WebApplicationBuilder AddApiVersioning(this WebApplicationBuilder builder)
    {
        builder.Services.AddApiVersioning(options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ReportApiVersions = true;
        });

        return builder;
    }
}
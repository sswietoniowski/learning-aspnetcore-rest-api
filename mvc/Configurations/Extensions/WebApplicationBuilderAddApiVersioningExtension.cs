using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

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
            //options.ApiVersionReader = new QueryStringApiVersionReader("v", "ver", "version", "api-version");
            //options.ApiVersionReader = new HeaderApiVersionReader("X-Version");
            //options.ApiVersionReader = new UrlSegmentApiVersionReader();
            // not recommended to use all at the same time, just for demonstration purposes
            options.ApiVersionReader = ApiVersionReader.Combine(
                new UrlSegmentApiVersionReader(),
                new HeaderApiVersionReader("X-Version"),
                new QueryStringApiVersionReader("v", "ver", "version", "api-version"));
        });

        return builder;
    }
}
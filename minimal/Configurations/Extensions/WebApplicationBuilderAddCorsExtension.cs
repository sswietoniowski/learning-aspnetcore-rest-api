namespace minimal.Configurations.Extensions;

public static class WebApplicationBuilderAddCorsExtension
{
    private static string[] GetAllowedOrigins(this WebApplicationBuilder builder)
    {
        return builder.Configuration.GetValue<string>("Cors:AllowedOrigins")
            ?.Split(",") ?? Array.Empty<string>();
    }

    public static WebApplicationBuilder AddCors(this WebApplicationBuilder builder)
    {
        var allowedOrigins = builder.GetAllowedOrigins();

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policyBuilder =>
            {
                policyBuilder
                    .WithOrigins(allowedOrigins)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .WithExposedHeaders("X-Pagination");
            });
        });

        return builder;
    }
}
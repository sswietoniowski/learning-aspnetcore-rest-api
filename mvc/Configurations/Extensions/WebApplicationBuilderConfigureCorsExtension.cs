namespace mvc.Configurations.Extensions;

public static class WebApplicationBuilderConfigureCorsExtension
{
    public static void ConfigureCors(this WebApplicationBuilder builder)
    {
        var allowedOrigins = builder.Configuration.GetValue<string>("Cors:AllowedOrigins")?.Split(",") ?? Array.Empty<string>();
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
    }
}
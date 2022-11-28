namespace mvc.Configurations.Extensions;

public static class WebApplicationBuilderAddCorsExtension
{
    private static string AllowedOrigins =>    
        builder.Configuration.GetValue<string>("Cors:AllowedOrigins")
            ?.Split(",") ?? Array.Empty<string>();

    public static WebApplicationBuilder AddCors(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policyBuilder =>
            {
                policyBuilder
                    .WithOrigins(AllowedOrigins)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .WithExposedHeaders("X-Pagination");
            });
        });

        return builder;
    }
}
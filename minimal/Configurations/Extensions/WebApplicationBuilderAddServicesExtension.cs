using minimal.Services;

namespace minimal.Configurations.Extensions;

public static class WebApplicationBuilderAddServicesExtension
{
    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IQuotesService, QuotesService>();
    }
}
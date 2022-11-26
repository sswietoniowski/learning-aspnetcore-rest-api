using Microsoft.EntityFrameworkCore;
using mvc.DataAccess.Data;
using mvc.DataAccess.Repository;
using mvc.DataAccess.Repository.Interfaces;

namespace mvc.Configurations.Extensions;

public static class WebApplicationBuilderConfigurePersistenceExtension
{
    public static void ConfigurePersistence(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<QuotesDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("QuotesDb"));
        });

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
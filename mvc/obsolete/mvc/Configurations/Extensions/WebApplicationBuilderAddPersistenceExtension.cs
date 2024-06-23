using Microsoft.EntityFrameworkCore;
using mvc.DataAccess.Data;
using mvc.DataAccess.Repository;
using mvc.DataAccess.Repository.Interfaces;
using mvc.Versions.v2.Services;

namespace mvc.Configurations.Extensions;

public static class WebApplicationBuilderAddPersistenceExtension
{
    public static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<QuotesDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("QuotesDb"));
        });

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IAuthorService, AuthorService>();
        builder.Services.AddScoped<ILanguageService, LanguageService>();
        builder.Services.AddScoped<IQuoteService, QuoteService>();

        return builder;
    }
}
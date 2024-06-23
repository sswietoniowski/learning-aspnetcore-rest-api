using Microsoft.EntityFrameworkCore;

using minimal.DataAccess.Data;
using minimal.DataAccess.Repository;
using minimal.DataAccess.Repository.Interfaces;

namespace minimal.Configurations.Extensions;

public static class WebApplicationBuilderAddPersistenceExtension
{
    public static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
        //// One might use this approach to build connection string (and then use sqlConnectionBuilder.ConnectionString)
        //// in case the user id and password is stored inside user secrets (but IMHO I would rather prefer to store 
        //// entire connection string inside user-secret and not bother to add that
        //var sqlConnectionBuilder = new SqlConnectionStringBuilder
        //{
        //    ConnectionString = builder.Configuration.GetConnectionString("QuotesDb"),
        //    UserID = configuration["UserID"],
        //    Password = configuration["Password"]
        //};

        builder.Services.AddDbContext<QuotesDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("QuotesDb"));
        });

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        return builder;
    }
}
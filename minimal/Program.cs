using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using minimal;
using minimal.DataAccess.Data;
using minimal.DataAccess.Repository;
using minimal.DataAccess.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

//// One might use this approach to build connection string (and then use sqlConnectionBuilder.ConnectionString)
//// in case the user id and password is stored inside user secrets (but IMHO I would rather prefer to store 
//// entire connection string inside user-secret and not bother to add that
//var sqlConnectionBuilder = new SqlConnectionStringBuilder
//{
//    ConnectionString = configuration.GetConnectionString("QuotesDb"),
//    UserID = configuration["UserID"],
//    Password = configuration["Password"]
//};

builder.Services.AddDbContext<QuotesDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("QuotesDb"));
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "minimal", Version = "v1" });
});

var allowedOrigins = builder.Configuration.GetValue<string>("Cors:AllowedOrigins")?.Split(",") ?? new string[0];
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

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.MapSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.MapQuoteEndpoints();

app.Run();

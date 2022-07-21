using Microsoft.EntityFrameworkCore;

using minimal.DataAccess.Data;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var environment = builder.Environment;

builder.Services.AddDbContext<QuotesDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("QuotesDb"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    
    app.UseSwagger();
    app.MapSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

using AutoMapper;

using Microsoft.EntityFrameworkCore;

using minimal.DataAccess.Data;
using minimal.DataAccess.Repository;
using minimal.DataAccess.Repository.Interfaces;
using minimal.DTOs;
using minimal.Models;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var environment = builder.Environment;

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

app.MapGet("api/quotes", async (IUnitOfWork unitOfWork, IMapper mapper) =>
{
    var quotes = await unitOfWork.QuoteRepository.GetAllAsync();
    var quotesDto = mapper.Map<IEnumerable<QuoteDto>>(quotes);

    return Results.Ok(quotesDto);
});

app.MapGet("api/quotes/{id}", async (int id, IUnitOfWork unitOfWork, IMapper mapper) =>
{
    var quote = await unitOfWork.QuoteRepository.GetAsync(id);

    if (quote is null)
    {
        return Results.NotFound();
    }

    var quoteDto = mapper.Map<QuoteDto>(quote);

    return Results.Ok(quoteDto);
});

app.MapPost("api/quotes", async (QuoteForCreationDto quoteDto, IUnitOfWork unitOfWork, IMapper mapper) =>
{
    var quote = mapper.Map<Quote>(quoteDto);

    await unitOfWork.QuoteRepository.AddAsync(quote);
    await unitOfWork.SaveAsync();

    var createdQuoteDto = mapper.Map<QuoteDto>(quote);

    return Results.Created($"/api/quotes/{createdQuoteDto.Id}", createdQuoteDto);
});

app.MapPut("api/quotes/{id}", async (int id, QuoteForUpdateDto quoteDto, IUnitOfWork unitOfWork, IMapper mapper) =>
{
    var quoteToUpdate = await unitOfWork.QuoteRepository.GetAsync(id);

    if (quoteToUpdate is null)
    {
        return Results.NotFound();
    }

    mapper.Map(quoteDto, quoteToUpdate);

    unitOfWork.QuoteRepository.Modify(quoteToUpdate);
    await unitOfWork.SaveAsync();

    return Results.NoContent();
});

app.MapDelete("api/quotes/{id}", async (int id, IUnitOfWork unitOfWork, IMapper mapper) =>
{
    var quoteToDelete = await unitOfWork.QuoteRepository.GetAsync(id);

    if (quoteToDelete is null)
    {
        return Results.NotFound();
    }

    unitOfWork.QuoteRepository.Remove(quoteToDelete);
    await unitOfWork.SaveAsync();

    return Results.NoContent();
});

app.Run();

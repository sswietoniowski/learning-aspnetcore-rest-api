using AutoMapper;

using minimal.DataAccess.Entities;
using minimal.DataAccess.Repository.Interfaces;
using minimal.DTOs;

namespace minimal;

public static class WebApplicationUseMinimalApiEndpointsExtensions
{
    public static void UseMinimalApiEndpoints(this WebApplication app)
    {
        app.MapGet("api/quotes", async (IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var (quotes, _) = await unitOfWork.QuoteRepository.GetQuotesAsync();
            var quotesDto = mapper.Map<IEnumerable<QuoteDto>>(quotes);

            return Results.Ok(quotesDto);
        })
            .WithName("GetQuotes")
            .Produces<IEnumerable<QuoteDto>>()
            .ProducesProblem(StatusCodes.Status500InternalServerError);

        app.MapGet("api/quotes/{id:int}", async (int id, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var quote = await unitOfWork.QuoteRepository.GetByIdAsync(id);

            if (quote is null)
            {
                return Results.NotFound();
            }

            var quoteDto = mapper.Map<QuoteDto>(quote);

            return Results.Ok(quoteDto);
        })
            .WithName("GetQuote")
            .Produces<QuoteDto>()
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError);

        app.MapPost("api/quotes", async (QuoteForCreationDto quoteDto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var quote = mapper.Map<Quote>(quoteDto);

            await unitOfWork.QuoteRepository.AddAsync(quote);
            await unitOfWork.SaveAsync();

            var createdQuoteDto = mapper.Map<QuoteDto>(quote);

            return Results.CreatedAtRoute("GetQuote", new { id = createdQuoteDto.Id }, createdQuoteDto);
        })
            .WithName("CreateQuote")
            .Produces<QuoteDto>(StatusCodes.Status201Created)
            .ProducesValidationProblem() // Validation errors, not yet implemented
            .ProducesProblem(StatusCodes.Status500InternalServerError);

        app.MapPut("api/quotes/{id:int}", async (int id, QuoteForUpdateDto quoteDto, IUnitOfWork unitOfWork, IMapper mapper) =>
        {
            var quoteToUpdate = await unitOfWork.QuoteRepository.GetByIdAsync(id);

            if (quoteToUpdate is null)
            {
                return Results.NotFound();
            }

            mapper.Map(quoteDto, quoteToUpdate);

            unitOfWork.QuoteRepository.Modify(quoteToUpdate);
            await unitOfWork.SaveAsync();

            return Results.NoContent();
        })
            .WithName("UpdateQuote")
            .Produces(StatusCodes.Status204NoContent)
            .ProducesValidationProblem() // Validation errors, not yet implemented
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError);

        app.MapDelete("api/quotes/{id:int}", async (int id, IUnitOfWork unitOfWork) =>
        {
            var quoteToDelete = await unitOfWork.QuoteRepository.GetByIdAsync(id);

            if (quoteToDelete is null)
            {
                return Results.NotFound();
            }

            unitOfWork.QuoteRepository.Remove(quoteToDelete);
            await unitOfWork.SaveAsync();

            return Results.NoContent();
        })
            .WithName("DeleteQuote")
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}
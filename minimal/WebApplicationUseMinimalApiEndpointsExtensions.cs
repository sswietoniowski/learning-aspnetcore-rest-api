using minimal.DTOs;
using minimal.Services;

namespace minimal;

public static class WebApplicationUseMinimalApiEndpointsExtensions
{
    public static void UseMinimalApiEndpoints(this WebApplication app)
    {
        app.MapGet("api/quotes", async (IQuotesService quotesService) =>
        {
            var quotesDto = await quotesService.GetAllAsync();

            return Results.Ok(quotesDto);
        })
            .WithName("GetQuotes")
            .Produces<IEnumerable<QuoteDto>>()
            .ProducesProblem(StatusCodes.Status500InternalServerError);

        app.MapGet("api/quotes/{id:int}", async (int id, IQuotesService quotesService) =>
        {
            var quoteDto = await quotesService.GetByIdAsync(id);

            return Results.Ok(quoteDto);
        })
            .WithName("GetQuote")
            .Produces<QuoteDto>()
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError);

        app.MapPost("api/quotes", async (QuoteForCreationDto quoteDto, IQuotesService quotesService) =>
        {
            var createdQuoteDto = await quotesService.CreateAsync(quoteDto);

            return Results.CreatedAtRoute("GetQuote", new { id = createdQuoteDto.Id }, createdQuoteDto);
        })
            .WithName("CreateQuote")
            .Produces<QuoteDto>(StatusCodes.Status201Created)
            .ProducesValidationProblem() // Validation errors, not yet implemented
            .ProducesProblem(StatusCodes.Status500InternalServerError);

        app.MapPut("api/quotes/{id:int}", async (int id, QuoteForUpdateDto quoteDto, IQuotesService quotesService) =>
        {
            await quotesService.UpdateAsync(id, quoteDto);

            return Results.NoContent();
        })
            .WithName("UpdateQuote")
            .Produces(StatusCodes.Status204NoContent)
            .ProducesValidationProblem() // Validation errors, not yet implemented
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError);

        app.MapDelete("api/quotes/{id:int}", async (int id, IQuotesService quotesService) =>
        {
            await quotesService.DeleteAsync(id);

            return Results.NoContent();
        })
            .WithName("DeleteQuote")
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError);
    }
}
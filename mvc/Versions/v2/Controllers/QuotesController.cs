using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using mvc.Versions.v2.DTOs;
using mvc.Versions.v2.Services;
using System.Text.Json;
using Microsoft.AspNetCore.Http.Extensions;

namespace mvc.Versions.v2.Controllers;

[ApiController]
[Route("api/quotes")]
[Route("api/v{version:apiVersion}/quotes")]
[ApiVersion("2.0")]
public class QuotesController : ControllerBase
{
    private const int DEFAULT_QUOTES_PAGE_NUMBER = 1;
    private const int DEFAULT_QUOTES_PAGE_SIZE = 10;
    private const int MAX_QUOTES_PAGE_SIZE = 100;

    private readonly ILogger<QuotesController> _logger;
    private readonly IQuoteService _quoteService;

    public QuotesController(ILogger<QuotesController> logger, IQuoteService quoteService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _quoteService = quoteService ?? throw new ArgumentNullException(nameof(quoteService));
    }

    // GET: api/quotes
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<QuoteDto>>> GetQuotes(
        [FromQuery(Name = "filter_author")] string? author,
        [FromQuery(Name = "filter_language")] string? language,
        [FromQuery(Name = "search_text")] string? text,
        [FromQuery] int pageNumber = DEFAULT_QUOTES_PAGE_NUMBER,
        [FromQuery] int pageSize = DEFAULT_QUOTES_PAGE_SIZE)
    {
        _logger.LogInformation($"Calling: {nameof(GetQuotes)}");

        if (pageNumber <= 0)
        {
            ModelState.AddModelError(nameof(pageNumber), "Page number should be positive number!");
            return BadRequest(ModelState);
        }

        if (pageSize > MAX_QUOTES_PAGE_SIZE)
        {
            _logger.LogWarning($"Page size ({pageSize}) was adjusted beacause it was greater than the maximum page size {MAX_QUOTES_PAGE_SIZE}.");
            pageSize = MAX_QUOTES_PAGE_SIZE;
        }

        var (quotesDto, paginationMetadata) = await _quoteService.GetAsync(author, language, text, pageNumber, pageSize);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

        return Ok(quotesDto);
    }

    // GET: api/quotes/id
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<QuoteDto>> GetQuote(int id)
    {
        _logger.LogInformation($"Calling: {nameof(GetQuote)}");

        var quoteDto = await _quoteService.GetByIdAsync(id);

        return Ok(quoteDto);
    }

    // POST: api/quotes
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<QuoteDto>> CreateQuote([FromBody] QuoteForCreationDto quoteDto)
    {
        _logger.LogInformation($"Calling: {nameof(CreateQuote)}");

        var createdQuoteDto = await _quoteService.CreateAsync(quoteDto);

        // I'm using Created instead of CreatedAtAction or CreatedAtRoute because I'm using
        // multiple versioning strategies

        return Created(new Uri($"{Request.Path}/{createdQuoteDto.Id}", UriKind.Relative), createdQuoteDto);
    }

    // PUT: api/quotes/id
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateQuote(int id, [FromBody] QuoteForUpdateDto quoteDto)
    {
        _logger.LogInformation($"Calling: {nameof(UpdateQuote)}");

        await _quoteService.UpdateAsync(id, quoteDto);

        return NoContent();
    }

    // PATCH: api/quotes/id
    [HttpPatch("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> PartiallyUpdateQuote(int id, JsonPatchDocument<QuoteForUpdateDto> patchDocument)
    {
        _logger.LogInformation($"Calling: {nameof(PartiallyUpdateQuote)}");

        var quoteDtoToPatch = await _quoteService.GetForUpdateAsync(id);
        patchDocument.ApplyTo(quoteDtoToPatch, ModelState);

        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        if (!TryValidateModel(quoteDtoToPatch))
        {
            return ValidationProblem(ModelState);
        }

        await _quoteService.UpdatePartiallyAsync(id, quoteDtoToPatch);

        return NoContent();
    }

    // DELETE: api/quotes/id
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteQuote(int id)
    {
        _logger.LogInformation($"Calling: {nameof(DeleteQuote)}");

        await _quoteService.DeleteAsync(id);

        return NoContent();
    }
}
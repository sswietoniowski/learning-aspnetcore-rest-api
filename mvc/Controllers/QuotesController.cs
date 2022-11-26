using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using mvc.DataAccess.Entities;
using mvc.DataAccess.Repository.Interfaces;
using mvc.DTOs;
using System.Text.Json;

namespace mvc.Controllers;

[ApiController]
[Route("api/quotes")]
public class QuotesController : ControllerBase
{
    private const int DEFAULT_QUOTES_PAGE_NUMBER = 1;
    private const int DEFAULT_QUOTES_PAGE_SIZE = 10;
    private const int MAX_QUOTES_PAGE_SIZE = 100;

    private readonly ILogger<QuotesController> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public QuotesController(ILogger<QuotesController> logger, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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
        // handling errors with try-catch is the oldest and the easiest way to do it,
        // I'm using it only for this endpoint to show how to do that, for the rest of the endpoints
        // I will use a middleware to handle exceptions globally, depending on the configuration
        // setting it would be a custom middleware or the one provided by the framework

        try
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

            var (quotes, paginationMetadata) = await _unitOfWork.QuoteRepository.GetQuotesAsync(
                author, language, text, pageNumber, pageSize);
            var quotesDto = _mapper.Map<IEnumerable<QuoteDto>>(quotes);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            return Ok(quotesDto);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, $"An error occurred: {exception.Message}");

            return Problem(
                statusCode: 500,
                type: "Server Error",
                detail: exception.StackTrace,
                title: exception.Message);
        }
    }

    // GET: api/quotes/id
    [HttpGet("{id:int}", Name = nameof(GetQuote))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<QuoteDto>> GetQuote(int id)
    {
        _logger.LogInformation($"Calling: {nameof(GetQuote)}");

        var quote = await _unitOfWork.QuoteRepository.GetByIdAsync(id);

        if (quote is null)
        {
            return NotFound();
        }

        var quoteDto = _mapper.Map<QuoteDto>(quote);

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

        var quote = _mapper.Map<Quote>(quoteDto);

        await _unitOfWork.QuoteRepository.AddAsync(quote);
        await _unitOfWork.SaveAsync();

        var createdQuoteDto = _mapper.Map<QuoteDto>(quote);

        // useful info about differences between CreatedAtAction vs CreatedAtRoute:
        // https://ochzhen.com/blog/created-createdataction-createdatroute-methods-explained-aspnet-core
        return CreatedAtRoute(nameof(GetQuote), new { quote.Id }, createdQuoteDto);
    }

    // PUT: api/quotes/id
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateQuote(int id, [FromBody] QuoteForUpdateDto quoteDto)
    {
        _logger.LogInformation($"Calling: {nameof(UpdateQuote)}");

        var quoteToUpdate = await _unitOfWork.QuoteRepository.GetByIdAsync(id);

        if (quoteToUpdate is null)
        {
            return NotFound();
        }

        _mapper.Map(quoteDto, quoteToUpdate);

        _unitOfWork.QuoteRepository.Modify(quoteToUpdate);
        await _unitOfWork.SaveAsync();

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

        // Here you'll find more info about JSON Patch:
        // https://jsonpatch.com/

        var quoteToUpdate = await _unitOfWork.QuoteRepository.GetByIdAsync(id);

        if (quoteToUpdate is null)
        {
            return NotFound();
        }

        var quoteDtoToPatch = _mapper.Map<QuoteForUpdateDto>(quoteToUpdate);
        patchDocument.ApplyTo(quoteDtoToPatch, ModelState);

        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        if (!TryValidateModel(quoteDtoToPatch))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(quoteDtoToPatch, quoteToUpdate);

        _unitOfWork.QuoteRepository.Modify(quoteToUpdate);
        await _unitOfWork.SaveAsync();

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

        var quoteToDelete = await _unitOfWork.QuoteRepository.GetByIdAsync(id);

        if (quoteToDelete is null)
        {
            return NotFound();
        }

        _unitOfWork.QuoteRepository.Remove(quoteToDelete);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }
}
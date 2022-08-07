using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using mvc.DataAccess.Repository.Interfaces;
using mvc.DTOs;
using mvc.Models;

namespace mvc.Controllers
{
    [ApiController]
    [Route("api/quotes")]
    public class QuotesController : ControllerBase
    {
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
        public async Task<ActionResult<IEnumerable<QuoteDto>>> GetQuotes()
        {
            try
            {
                _logger.LogInformation($"Calling: {nameof(GetQuotes)}");

                var quotes = await _unitOfWork.QuoteRepository.GetAllAsync();
                var quotesDto = _mapper.Map<IEnumerable<QuoteDto>>(quotes);

                return Ok(quotesDto);
            }
            catch (Exception exception)
            {
                _logger.LogCritical($"Exception while calling {nameof(GetQuotes)}.", exception);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "A problem happened while handling your request.");
            }
        }

        // GET: api/quotes/id
        [HttpGet("{id}", Name = nameof(GetQuote))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<QuoteDto>> GetQuote(int id)
        {
            try
            {
                _logger.LogInformation($"Calling: {nameof(GetQuote)}");

                var quote = await _unitOfWork.QuoteRepository.GetAsync(id);

                if (quote is null)
                {
                    return NotFound();
                }

                var quoteDto = _mapper.Map<QuoteDto>(quote);

                return Ok(quoteDto);
            }
            catch (Exception exception)
            {
                _logger.LogCritical($"Exception while calling {nameof(GetQuote)}.", exception);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "A problem happened while handling your request.");
            }
        }

        // POST: api/quotes
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<QuoteDto>> CreateQuote([FromBody] QuoteForCreationDto quoteDto)
        {
            try
            {
                _logger.LogInformation($"Calling: {nameof(CreateQuote)}");

                var quote = _mapper.Map<Quote>(quoteDto);

                await _unitOfWork.QuoteRepository.AddAsync(quote);
                await _unitOfWork.SaveAsync();

                var createdQuoteDto = _mapper.Map<QuoteDto>(quote);

                // useful info about differences between CreatedAtAction vs CreatedAtRoute:
                // https://ochzhen.com/blog/created-createdataction-createdatroute-methods-explained-aspnet-core
                return CreatedAtRoute(nameof(GetQuote), new { Id = quote.Id }, createdQuoteDto);
            }
            catch (Exception exception)
            {
                _logger.LogCritical($"Exception while calling {nameof(GetQuote)}.", exception);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "A problem happened while handling your request.");
            }
        }

        // PUT: api/quotes/id
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateQuote(int id, [FromBody] QuoteForUpdateDto quoteDto)
        {
            try
            {
                _logger.LogInformation($"Calling: {nameof(UpdateQuote)}");

                var quoteToUpdate = await _unitOfWork.QuoteRepository.GetAsync(id);

                if (quoteToUpdate is null)
                {
                    return NotFound();
                }

                _mapper.Map(quoteDto, quoteToUpdate);

                _unitOfWork.QuoteRepository.Modify(quoteToUpdate);
                await _unitOfWork.SaveAsync();

                return NoContent();
            }
            catch (Exception exception)
            {
                _logger.LogCritical($"Exception while calling {nameof(GetQuote)}.", exception);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "A problem happened while handling your request.");
            }
        }

        // PATCH: api/quotes/id
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PartiallyUpdateQuote(int id, JsonPatchDocument<QuoteForUpdateDto> patchDocument)
        {
            try
            {
                _logger.LogInformation($"Calling: {nameof(PartiallyUpdateQuote)}");

                // Here you'll find more info about JSON Patch:
                // https://jsonpatch.com/

                var quoteToUpdate = await _unitOfWork.QuoteRepository.GetAsync(id);

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
            catch (Exception exception)
            {
                _logger.LogCritical($"Exception while calling {nameof(GetQuote)}.", exception);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "A problem happened while handling your request.");
            }
        }

        // DELETE: api/quotes/id
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteQuote(int id)
        {
            try
            {
                _logger.LogInformation($"Calling: {nameof(DeleteQuote)}");

                var quoteToDelete = await _unitOfWork.QuoteRepository.GetAsync(id);

                if (quoteToDelete is null)
                {
                    return NotFound();
                }

                _unitOfWork.QuoteRepository.Remove(quoteToDelete);
                await _unitOfWork.SaveAsync();

                return NoContent();
            }
            catch (Exception exception)
            {
                _logger.LogCritical($"Exception while calling {nameof(GetQuote)}.", exception);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "A problem happened while handling your request.");
            }
        }
    }
}
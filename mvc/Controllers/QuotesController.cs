using System;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using mvc.DataAccess.Repository.Interfaces;
using mvc.DTOs;
using mvc.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mvc.Controllers
{
    [ApiController]
    [Route("api/quotes")]
    public class QuotesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuotesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/quotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuoteDto>>> GetQuotes()
        {
            var quotes = await _unitOfWork.QuoteRepository.GetAllAsync();
            var quotesDto = _mapper.Map<IEnumerable<QuoteDto>>(quotes);

            return Ok(quotesDto);
        }

        // GET: api/quotes/id
        [HttpGet("{id}", Name = nameof(GetQuote))]
        public async Task<ActionResult<QuoteDto>> GetQuote(int id)
        {
            var quote = await _unitOfWork.QuoteRepository.GetAsync(id);

            if (quote is null)
            {
                return NotFound();
            }

            var quoteDto = _mapper.Map<QuoteDto>(quote);

            return Ok(quoteDto);
        }

        // POST: api/quotes
        [HttpPost]
        public async Task<ActionResult<QuoteDto>> PostQuote([FromBody] CreateQuoteDto quoteDto)
        {
            var quote = _mapper.Map<Quote>(quoteDto);

            await _unitOfWork.QuoteRepository.AddAsync(quote);
            await _unitOfWork.SaveAsync();

            var createdQuoteDto = _mapper.Map<QuoteDto>(quote);

            // useful info about differences between CreatedAtAction vs CreatedAtRoute:
            // https://ochzhen.com/blog/created-createdataction-createdatroute-methods-explained-aspnet-core
            return CreatedAtRoute(nameof(GetQuote), new { Id = quote.Id }, createdQuoteDto);
        }

        // PUT: api/quotes/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuote(int id, [FromBody] UpdateQuoteDto quoteDto)
        {
            if (id != quoteDto.Id)
            {
                return BadRequest();
            }

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

        // PATCH: api/quotes/id
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchQuote(int id, JsonPatchDocument<UpdateQuoteDto> patchDocument)
        {
            // Here you'll find more info about JSON Patch:
            // https://jsonpatch.com/

            var quoteToUpdate = await _unitOfWork.QuoteRepository.GetAsync(id);

            if (quoteToUpdate is null)
            {
                return NotFound();
            }

            var quoteDtoToPatch = _mapper.Map<UpdateQuoteDto>(quoteToUpdate);
            patchDocument.ApplyTo(quoteDtoToPatch, ModelState);

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
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuote(int id)
        {
            var quoteToDelete = await _unitOfWork.QuoteRepository.GetAsync(id);

            if (quoteToDelete is null)
            {
                return NotFound();
            }

            _unitOfWork.QuoteRepository.Remove(quoteToDelete);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}
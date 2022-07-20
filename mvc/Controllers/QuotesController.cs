using Microsoft.AspNetCore.Mvc;
using mvc.DataAccess.Data;
using mvc.Models;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
using mvc.DataAccess.Repository.Interfaces;
using mvc.DTOs;

namespace mvc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuotesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuotesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/quotes
        [HttpGet]
        public ActionResult<IEnumerable<QuoteDto>> GetQuotes()
        {
            var quotes = _unitOfWork.QuoteRepository.GetAll();
            var quotesDto = _mapper.Map<IEnumerable<QuoteDto>>(quotes);

            return Ok(quotesDto);
        }

        // GET: api/quotes/id
        [HttpGet("{id}", Name = nameof(GetQuote))]
        public ActionResult<QuoteDto> GetQuote(int id)
        {
            var quote = _unitOfWork.QuoteRepository.Get(id);

            if (quote is null)
            {
                return NotFound();
            }

            var quoteDto = _mapper.Map<QuoteDto>(quote);

            return Ok(quoteDto);
        }

        // POST: api/quotes
        [HttpPost]
        public ActionResult<QuoteDto> PostQuote([FromBody] CreateQuoteDto quoteDto)
        {
            var quote = _mapper.Map<Quote>(quoteDto);

            _unitOfWork.QuoteRepository.Add(quote);
            _unitOfWork.Save();

            var createdQuoteDto = _mapper.Map<QuoteDto>(quote);

            // useful info about differences between CreatedAtAction vs CreatedAtRoute:
            // https://ochzhen.com/blog/created-createdataction-createdatroute-methods-explained-aspnet-core
            return CreatedAtRoute(nameof(GetQuote), new { Id = quote.Id }, createdQuoteDto);
        }

        // PUT: api/quotes/id
        [HttpPut("{id}")]
        public IActionResult PutQuote(int id, [FromBody] UpdateQuoteDto quoteDto)
        {
            if (id != quoteDto.Id)
            {
                return BadRequest();
            }

            var quoteToUpdate = _unitOfWork.QuoteRepository.Get(id);

            if (quoteToUpdate is null)
            {
                return NotFound();
            }

            _mapper.Map(quoteDto, quoteToUpdate);

            _unitOfWork.QuoteRepository.Modify(quoteToUpdate);
            _unitOfWork.Save();

            return NoContent();
        }

        // PATCH: api/quotes/id
        [HttpPatch("{id}")]
        public IActionResult PatchQuote(int id, JsonPatchDocument<UpdateQuoteDto> patchDocument)
        {
            // Here you'll find more info about JSON Patch:
            // https://jsonpatch.com/

            var quoteToUpdate = _unitOfWork.QuoteRepository.Get(id);

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
            _unitOfWork.Save();

            return NoContent();
        }

        // DELETE: api/quotes/id
        [HttpDelete("{id}")]
        public IActionResult DeleteQuote(int id)
        {
            var quoteToDelete = _unitOfWork.QuoteRepository.Get(id);

            if (quoteToDelete is null)
            {
                return NotFound();
            }

            _unitOfWork.QuoteRepository.Remove(quoteToDelete);
            _unitOfWork.Save();

            return NoContent();
        }
    }
}
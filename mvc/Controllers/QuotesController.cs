using Microsoft.AspNetCore.Mvc;
using mvc.DataAccess.Data;
using mvc.Models;
using System.Collections.Generic;
using AutoMapper;
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
        [HttpGet("{id}")]
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quote = _mapper.Map<Quote>(quoteDto);

            _unitOfWork.QuoteRepository.Add(quote);
            _unitOfWork.Save();

            var createdQuoteDto = _mapper.Map<QuoteDto>(quote);

            return CreatedAtAction(nameof(GetQuote), new QuoteDto { Id = quote.Id }, createdQuoteDto);
        }

        // PUT: api/quotes/id
        [HttpPut("{id}")]
        public IActionResult PutQuote(int id, [FromBody] UpdateQuoteDto quoteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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
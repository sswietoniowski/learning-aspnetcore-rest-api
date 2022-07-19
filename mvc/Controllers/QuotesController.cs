using Microsoft.AspNetCore.Mvc;
using mvc.DataAccess.Data;
using mvc.Models;
using System.Collections.Generic;
using mvc.DataAccess.Repository.Interfaces;

namespace mvc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuotesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuotesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/quotes
        [HttpGet]
        public ActionResult<IEnumerable<Quote>> GetQuotes()
        {
            return Ok(_unitOfWork.QuoteRepository.GetAll());
        }

        // GET: api/quotes/id
        [HttpGet("{id}")]
        public ActionResult<Quote> GetQuote(int id)
        {
            var quote = _unitOfWork.QuoteRepository.Get(id);

            if (quote is null)
            {
                return NotFound();
            }

            return Ok(quote);
        }

        // POST: api/quotes
        [HttpPost]
        public IActionResult PostQuote([FromBody] Quote quote)
        {
            _unitOfWork.QuoteRepository.Add(quote);
            _unitOfWork.Save();

            return CreatedAtAction(nameof(GetQuote), new Quote { Id = quote.Id }, quote);
        }

        // PUT: api/quotes/id
        [HttpPut("{id}")]
        public IActionResult PutQuote(int id, [FromBody] Quote quote)
        {
            if (id != quote.Id)
            {
                return BadRequest();
            }

            var quoteToUpdate = _unitOfWork.QuoteRepository.Get(id);

            if (quoteToUpdate is null)
            {
                return NotFound();
            }

            quoteToUpdate.Text = quote.Text;
            quoteToUpdate.Author = quote.Author;
            quoteToUpdate.Language = quote.Language;

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
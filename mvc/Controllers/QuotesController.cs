using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using mvc.DataAccess;

namespace mvc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuotesController : ControllerBase
    {
        private readonly QuotesDbContext _context;

        public QuotesController(QuotesDbContext context)
        {
            _context = context;
        }

        // GET: api/quotes
        [HttpGet]
        public ActionResult<IEnumerable<Quote>> GetAll()
        {
            return Ok(_context.Quotes);
        }

        // GET: api/quotes/id
        [HttpGet("{id}")]
        public ActionResult<Quote> GetById(int id)
        {
            var quote = _context.Quotes.Find(id);

            if (quote is null)
            {
                return NotFound();
            }

            return Ok(quote);
        }

        // POST: api/quotes
        [HttpPost]
        public ActionResult<Quote> Create([FromBody] Quote quote)
        {
            _context.Quotes.Add(quote);
            _context.SaveChanges();

            return Ok(quote);
        }

        [HttpPut("{id}")]
        public ActionResult<Quote> Update(int id, [FromBody] Quote quote)
        {
            var quoteToUpdate = _context.Quotes.Find(id);

            if (quoteToUpdate is null)
            {
                return NotFound();
            }

            quoteToUpdate.Text = quote.Text;
            quoteToUpdate.Author = quote.Author;
            quoteToUpdate.Language = quote.Language;

            _context.SaveChanges();

            return Ok(quoteToUpdate);
        }

        [HttpDelete("{id}")]
        public ActionResult<Quote> Delete(int id)
        {
            var quoteToDelete = _context.Quotes.Find(id);

            if (quoteToDelete is null)
            {
                return NotFound();
            }

            _context.Quotes.Remove(quoteToDelete);

            _context.SaveChanges();

            return Ok(quoteToDelete);
        }
    }
}
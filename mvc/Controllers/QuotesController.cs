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

        [HttpPost]
        public ActionResult<Quote> Create([FromBody] Quote quote)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<Quote> Update(int id, [FromBody] Quote quote)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Quote> Delete(int id)
        {
            return Ok();
        }
    }
}
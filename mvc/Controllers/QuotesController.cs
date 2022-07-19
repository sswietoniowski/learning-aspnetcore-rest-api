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

        [HttpGet]
        public ActionResult<IEnumerable<Quote>> GetAll()
        {
            return _context.Quotes;
        }

        [HttpGet("{id}")]
        public ActionResult<Quote> GetById(int id)
        {
            return _context.Quotes.Find(id);
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
using System.Collections.Generic;
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
            return Ok();
        }
    }
}
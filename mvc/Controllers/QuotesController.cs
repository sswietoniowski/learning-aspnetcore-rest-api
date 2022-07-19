using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuotesController : ControllerBase
    {
        public QuotesController()
        {
        }

        public ActionResult<IEnumerable<Quote>> GetAll()
        {
            return Ok();
        }
    }
}
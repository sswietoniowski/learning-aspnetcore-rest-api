using Microsoft.EntityFrameworkCore;
using mvc.DataAccess.Data;
using mvc.DataAccess.Repository.Interfaces;
using mvc.Models;

namespace mvc.DataAccess.Repository
{
    public class QuoteRepository : Repository<Quote>, IQuoteRepository
    {
        public QuoteRepository(QuotesDbContext context) : base(context)
        {
        }
    }
}

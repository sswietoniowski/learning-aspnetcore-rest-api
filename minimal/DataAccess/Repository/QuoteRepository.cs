using minimal.DataAccess.Data;
using minimal.DataAccess.Repository.Interfaces;
using minimal.Models;

namespace minimal.DataAccess.Repository;

public class QuoteRepository : Repository<Quote>, IQuoteRepository
{
    public QuoteRepository(QuotesDbContext context) : base(context)
    {
    }
}
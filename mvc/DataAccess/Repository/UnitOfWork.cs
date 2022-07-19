using Microsoft.EntityFrameworkCore;
using mvc.DataAccess.Data;
using mvc.DataAccess.Repository.Interfaces;

namespace mvc.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QuotesDbContext _context;

        public IQuoteRepository QuoteRepository { get; }

        public UnitOfWork(QuotesDbContext context)
        {
            _context = context;
            QuoteRepository = new QuoteRepository(_context);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

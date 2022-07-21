using minimal.DataAccess.Data;
using minimal.DataAccess.Repository.Interfaces;

namespace minimal.DataAccess.Repository
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
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context?.Dispose();
            }
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

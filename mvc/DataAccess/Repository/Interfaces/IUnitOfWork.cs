using System;

namespace mvc.DataAccess.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IQuoteRepository QuoteRepository { get; }
        void Save();
    }
}

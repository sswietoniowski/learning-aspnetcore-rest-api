using System;
using System.Threading.Tasks;

namespace mvc.DataAccess.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IQuoteRepository QuoteRepository { get; }
        Task SaveAsync();
    }
}

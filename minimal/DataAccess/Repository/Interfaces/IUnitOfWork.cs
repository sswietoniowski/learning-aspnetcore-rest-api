namespace minimal.DataAccess.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IQuoteRepository QuoteRepository { get; }
        Task SaveAsync();
    }
}

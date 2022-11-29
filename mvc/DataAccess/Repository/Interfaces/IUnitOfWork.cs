namespace mvc.DataAccess.Repository.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IAuthorRepository AuthorRepository { get; }
    ILanguageRepository LanguageRepository { get; }
    IQuoteRepository QuoteRepository { get; }
    Task SaveAsync();
}
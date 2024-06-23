using minimal.DataAccess.Entities;

namespace minimal.DataAccess.Repository.Interfaces;

public interface IQuoteRepository : IRepository<Quote>
{
    const int DefaultQuotesPageNumber = 1;
    const int DefaultQuotesPageSize = 10;

    Task<(IReadOnlyList<Quote>, PaginationMetadata)> GetQuotesAsync(
        string? author = null,
        string? language = null,
        string? text = null,
        int pageNumber = DefaultQuotesPageNumber, 
        int pageSize = DefaultQuotesPageSize);
    Task<bool> QuoteExists(int id);
}
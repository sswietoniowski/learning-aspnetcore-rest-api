using mvc.DataAccess.Entities;

namespace mvc.DataAccess.Repository.Interfaces;

public interface IQuoteRepository : IRepository<QuoteEntity>
{
    const int DefaultQuotesPageNumber = 1;
    const int DefaultQuotesPageSize = 10;

    Task<(IReadOnlyList<QuoteEntity>, PaginationMetadata)> GetQuotesAsync(
        string? author = null,
        string? language = null,
        string? text = null,
        int pageNumber = DefaultQuotesPageNumber,
        int pageSize = DefaultQuotesPageSize);
    Task<bool> QuoteExists(int id);
}
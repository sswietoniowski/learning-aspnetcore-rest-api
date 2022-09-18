using minimal.DataAccess.Entities;

namespace minimal.DataAccess.Repository.Interfaces;

public interface IQuoteRepository : IRepository<QuoteEntity>
{
    Task<(IReadOnlyList<QuoteEntity>, PaginationMetadata)> GetQuotesAsync(
        string? author = null,
        string? language = null,
        string? text = null,
        int pageNumber = default, int pageSize = default);
    Task<bool> QuoteExists(int id);
}
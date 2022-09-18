using mvc.DataAccess.Entities;

namespace mvc.DataAccess.Repository.Interfaces;

public interface IQuoteRepository : IRepository<QuoteEntity>
{
    Task<(IReadOnlyList<QuoteEntity>, PaginationMetadata)> GetQuotesAsync(
        string? author,
        string? language,
        string? text,
        int pageNumber = default, int pageSize = default);
    Task<bool> QuoteExists(int id);
}
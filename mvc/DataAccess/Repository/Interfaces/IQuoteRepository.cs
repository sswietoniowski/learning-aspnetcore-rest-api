using mvc.Models;

namespace mvc.DataAccess.Repository.Interfaces;

public interface IQuoteRepository : IRepository<Quote>
{
    Task<(IReadOnlyList<Quote>, PaginationMetadata)> GetQuotesAsync(
        string? author,
        string? language,
        string? text,
        int pageNumber = default, int pageSize = default);
    Task<bool> QuoteExists(int id);
}
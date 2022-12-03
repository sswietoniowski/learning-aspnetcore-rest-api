using mvc.DataAccess.Data;
using mvc.DataAccess.Entities;
using mvc.DataAccess.Repository.Interfaces;
using mvc.DTOs;
using System.Linq.Expressions;

namespace mvc.DataAccess.Repository;

public class QuoteRepository : Repository<Quote>, IQuoteRepository
{
    private const int DEFAULT_QUOTES_PAGE_NUMBER = 1;
    private const int DEFAULT_QUOTES_PAGE_SIZE = 10;

    public QuoteRepository(QuotesDbContext context) : base(context)
    {
    }

    public async Task<(IReadOnlyList<Quote>, PaginationMetadata)> GetQuotesAsync(
        string? author = null,
        string? language = null,
        string? text = null,
        int pageNumber = IQuoteRepository.DefaultQuotesPageNumber,
        int pageSize = IQuoteRepository.DefaultQuotesPageSize)
    {
        Expression<Func<Quote, bool>>? filter = null;
        Func<IQueryable<Quote>, IOrderedQueryable<Quote>>? orderBy = (q) => q.OrderBy(q => q.Id);

        if (!string.IsNullOrWhiteSpace(author))
        {
            filter = filter is null
                ? q => q.Author != null && q.Author.Name == author
                : filter.And(q => q.Author != null && q.Author.Name == author);
        }

        if (!string.IsNullOrWhiteSpace(language))
        {
            filter = filter is null
                ? q => q.Language != null && q.Language.Name == language
                : filter.And(q => q.Language != null && q.Language.Name == language);
        }

        if (!string.IsNullOrWhiteSpace(text))
        {
            filter = filter is null ? q => q.Text.Contains(text) : filter.And(q => q.Text.Contains(text));
        }

        orderBy = q => q.OrderBy(q => q.Id);

        return await GetAsync(
            filter: filter,
            includeProperties: "Author,Language",
            orderBy: orderBy,
            pageNumber: pageNumber,
            pageSize: pageSize);
    }

    public async Task<Quote?> GetQuoteAsync(int id) => await GetFirstOrDefaultAsync(
        filter: q => q.Id == id, includeProperties: "Author,Language");

    public async Task<bool> QuoteExists(int id) => await GetByIdAsync(id) is not null;
}
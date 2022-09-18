using minimal.DataAccess.Data;
using minimal.DataAccess.Entities;
using minimal.DataAccess.Repository.Interfaces;

using System.Linq.Expressions;

namespace minimal.DataAccess.Repository;

public class QuoteRepository : Repository<QuoteEntity>, IQuoteRepository
{
    public QuoteRepository(QuotesDbContext context) : base(context)
    {
    }

    public async Task<(IReadOnlyList<QuoteEntity>, PaginationMetadata)> GetQuotesAsync(
        string? author = null,
        string? language = null,
        string? text = null,
        int pageNumber = IQuoteRepository.DefaultQuotesPageNumber, 
        int pageSize = IQuoteRepository.DefaultQuotesPageSize)
    {
        Expression<Func<QuoteEntity, bool>>? filter = null;
        Func<IQueryable<QuoteEntity>, IOrderedQueryable<QuoteEntity>>? orderBy = (q) => q.OrderBy(q => q.Id);

        if (!string.IsNullOrWhiteSpace(author))
        {
            filter = filter is null ? q => q.Author == author : filter.And(q => q.Author == author);
        }

        if (!string.IsNullOrWhiteSpace(language))
        {
            filter = filter is null ? q => q.Language == language : filter.And(q => q.Language == language);
        }

        if (!string.IsNullOrWhiteSpace(text))
        {
            filter = filter is null ? q => q.Text.Contains(text) : filter.And(q => q.Text.Contains(text));
        }

        orderBy = q => q.OrderBy(q => q.Id);

        return await GetAsync(
            filter: filter,
            orderBy: orderBy,
            pageNumber: pageNumber,
            pageSize: pageSize);
    }

    public async Task<bool> QuoteExists(int id) => await GetByIdAsync(id) is not null;
}
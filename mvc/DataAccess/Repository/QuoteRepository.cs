using mvc.DataAccess.Data;
using mvc.DataAccess.Repository.Interfaces;
using mvc.Models;
using System.Linq.Expressions;

namespace mvc.DataAccess.Repository;

public class QuoteRepository : Repository<Quote>, IQuoteRepository
{
    public QuoteRepository(QuotesDbContext context) : base(context)
    {
    }

    public async Task<(IReadOnlyList<Quote>, PaginationMetadata)> GetQuotesAsync(
        string? author, 
        string? language, 
        string? text, 
        int pageNumber = 0, int pageSize = 0)
    {
        Expression<Func<Quote, bool>>? filter = null;
        Func<IQueryable<Quote>, IOrderedQueryable<Quote>>? orderBy = null;

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
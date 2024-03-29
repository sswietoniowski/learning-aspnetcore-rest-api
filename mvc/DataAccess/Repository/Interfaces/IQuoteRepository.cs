﻿using mvc.DataAccess.Entities;
using mvc.DTOs;

namespace mvc.DataAccess.Repository.Interfaces;

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

    Task<Quote?> GetQuoteAsync(int id);

    Task<bool> QuoteExists(int id);
}
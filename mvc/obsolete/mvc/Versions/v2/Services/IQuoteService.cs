using mvc.DataAccess.Entities;
using mvc.DataAccess.Repository.Interfaces;
using mvc.DTOs;
using mvc.Versions.v2.DTOs;

namespace mvc.Versions.v2.Services;

public interface IQuoteService : IService<Quote, QuoteDto, QuoteForCreationDto, QuoteForUpdateDto>
{
    Task<(IEnumerable<QuoteDto>, PaginationMetadata)> GetAsync(
        string? author = null,
        string? language = null,
        string? text = null,
        int pageNumber = IQuoteRepository.DefaultQuotesPageNumber,
        int pageSize = IQuoteRepository.DefaultQuotesPageSize);
    Task<QuoteForUpdateDto> GetForUpdateAsync(int id);
    Task UpdatePartiallyAsync(int id, QuoteForUpdateDto quoteToUpdateDto);
}
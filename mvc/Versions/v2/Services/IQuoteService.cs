using mvc.DataAccess.Repository.Interfaces;
using mvc.DTOs;
using mvc.Versions.v2.DTOs;

namespace mvc.Versions.v2.Services;

public interface IQuoteService
{
    Task<IEnumerable<QuoteDto>> GetAllAsync();
    Task<QuoteDto> GetByIdAsync(int id);
    Task<(IEnumerable<QuoteDto>, PaginationMetadata)> GetAsync(
        string? author = null,
        string? language = null,
        string? text = null,
        int pageNumber = IQuoteRepository.DefaultQuotesPageNumber,
        int pageSize = IQuoteRepository.DefaultQuotesPageSize);
    Task<QuoteDto> CreateAsync(QuoteForCreationDto quoteDto);
    Task UpdateAsync(int id, QuoteForUpdateDto quoteDto);
    Task<QuoteForUpdateDto> GetForUpdateAsync(int id);
    Task UpdatePartiallyAsync(int id, QuoteForUpdateDto quoteToUpdateDto);
    Task DeleteAsync(int id);
}
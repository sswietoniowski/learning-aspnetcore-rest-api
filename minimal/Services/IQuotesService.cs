using minimal.DTOs;

namespace minimal.Services;

public interface IQuotesService
{
    Task<IEnumerable<QuoteDto>> GetAllAsync();
    Task<QuoteDto> GetByIdAsync(int id);
    Task<QuoteDto> CreateAsync(QuoteForCreationDto quoteDto);
    Task UpdateAsync(int id, QuoteForUpdateDto quoteDto);
    Task DeleteAsync(int id);
}
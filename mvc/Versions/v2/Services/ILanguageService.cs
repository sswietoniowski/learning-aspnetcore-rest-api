using mvc.Versions.v2.DTOs;

namespace mvc.Versions.v2.Services;

public interface ILanguageService
{
    Task<IEnumerable<LanguageDto>> GetAllAsync();
    Task<LanguageDto> GetByIdAsync(int id);
    Task<LanguageDto> CreateAsync(LanguageForCreationDto languageDto);
    Task UpdateAsync(int id, LanguageForUpdateDto languageDto);
    Task DeleteAsync(int id);
}
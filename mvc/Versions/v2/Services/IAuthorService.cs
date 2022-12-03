using mvc.Versions.v2.DTOs;

namespace mvc.Versions.v2.Services;

public interface IAuthorService
{
    Task<IEnumerable<AuthorDto>> GetAllAsync();
    Task<AuthorDto> GetByIdAsync(int id);
    Task<AuthorDto> CreateAsync(AuthorForCreationDto authorDto);
    Task UpdateAsync(int id, AuthorForUpdateDto authorDto);
    Task DeleteAsync(int id);
}
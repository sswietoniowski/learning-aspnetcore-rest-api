using mvc.DataAccess.Entities;
using mvc.Versions.v2.DTOs;

namespace mvc.Versions.v2.Services;

public interface IService<TEntity, TDto, TForCreationDto, TForUpdateDto>
    where TEntity: class, IEntity
    where TDto : class, IDto
    where TForCreationDto : class, IDto
    where TForUpdateDto : class, IDto
{
    Task<IEnumerable<TDto>> GetAllAsync();
    Task<TDto> GetByIdAsync(int id);
    Task<TDto> CreateAsync(TForCreationDto dto);
    Task UpdateAsync(int id, TForUpdateDto dto);
    Task DeleteAsync(int id);
}

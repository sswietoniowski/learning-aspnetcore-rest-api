using mvc.DataAccess.Entities;
using mvc.Versions.v2.DTOs;

namespace mvc.Versions.v2.Services;

public interface ILanguageService : IService<Language, LanguageDto, LanguageForCreationDto, LanguageForUpdateDto>
{
}

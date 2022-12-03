using mvc.DataAccess.Entities;
using mvc.Versions.v2.DTOs;

namespace mvc.Versions.v2.Services;

public interface IAuthorService : IService<Author, AuthorDto, AuthorForCreationDto, AuthorForUpdateDto>
{
}
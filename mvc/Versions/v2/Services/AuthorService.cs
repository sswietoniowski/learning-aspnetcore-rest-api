using AutoMapper;
using mvc.DataAccess.Entities;
using mvc.DataAccess.Repository.Interfaces;
using mvc.Versions.v2.DTOs;

namespace mvc.Versions.v2.Services;

public class AuthorService : Service<Author, AuthorDto, AuthorForCreationDto, AuthorForUpdateDto, IAuthorRepository>, IAuthorService
{
    public AuthorService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
        Repository = unitOfWork.AuthorRepository;
    }
}
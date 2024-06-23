using AutoMapper;
using mvc.DataAccess.Entities;
using mvc.DataAccess.Repository.Interfaces;
using mvc.Versions.v2.DTOs;

namespace mvc.Versions.v2.Services;

public class LanguageService : Service<Language, LanguageDto, LanguageForCreationDto, LanguageForUpdateDto, ILanguageRepository>, ILanguageService
{
    public LanguageService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
        Repository = unitOfWork.LanguageRepository;
    }
}
using AutoMapper;
using mvc.Configurations.Exceptions;
using mvc.DataAccess.Entities;
using mvc.DataAccess.Repository.Interfaces;
using mvc.Versions.v2.DTOs;

namespace mvc.Versions.v2.Services;

public class LanguageService : ILanguageService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public LanguageService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LanguageDto>> GetAllAsync()
    {
        var (languages, _) = await _unitOfWork.LanguageRepository.GetAsync();

        var languagesDto = _mapper.Map<IEnumerable<LanguageDto>>(languages);

        return languagesDto;
    }

    public async Task<LanguageDto> GetByIdAsync(int id)
    {
        var language = await _unitOfWork.LanguageRepository.GetByIdAsync(id) ?? throw new NotFoundApiException();

        var languageDto = _mapper.Map<LanguageDto>(language);

        return languageDto;
    }

    public async Task<LanguageDto> CreateAsync(LanguageForCreationDto languageDto)
    {
        var language = _mapper.Map<Language>(languageDto);

        await _unitOfWork.LanguageRepository.AddAsync(language);
        await _unitOfWork.SaveAsync();

        var createdLaguageDto = _mapper.Map<LanguageDto>(language);

        return createdLaguageDto;
    }

    public async Task UpdateAsync(int id, LanguageForUpdateDto languageDto)
    {
        var languageToUpdate = await _unitOfWork.LanguageRepository.GetByIdAsync(id) ?? throw new NotFoundApiException();

        _mapper.Map(languageDto, languageToUpdate);

        _unitOfWork.LanguageRepository.Modify(languageToUpdate);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var languageToDelete = await _unitOfWork.LanguageRepository.GetByIdAsync(id) ?? throw new NotFoundApiException();

        _unitOfWork.LanguageRepository.Remove(languageToDelete);
        await _unitOfWork.SaveAsync();
    }
}
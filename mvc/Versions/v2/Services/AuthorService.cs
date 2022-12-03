using AutoMapper;
using mvc.Configurations.Exceptions;
using mvc.DataAccess.Entities;
using mvc.DataAccess.Repository.Interfaces;
using mvc.Versions.v2.DTOs;

namespace mvc.Versions.v2.Services;

public class AuthorService : IAuthorService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AuthorService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AuthorDto>> GetAllAsync()
    {
        var (authors, _) = await _unitOfWork.AuthorRepository.GetAsync();

        var authorsDto = _mapper.Map<IEnumerable<AuthorDto>>(authors);

        return authorsDto;
    }

    public async Task<AuthorDto> GetByIdAsync(int id)
    {
        var author = await _unitOfWork.AuthorRepository.GetByIdAsync(id) ?? throw new NotFoundApiException();

        var authorDto = _mapper.Map<AuthorDto>(author);

        return authorDto;
    }

    public async Task<AuthorDto> CreateAsync(AuthorForCreationDto authorDto)
    {
        var author = _mapper.Map<Author>(authorDto);

        await _unitOfWork.AuthorRepository.AddAsync(author);
        await _unitOfWork.SaveAsync();

        var createdAuthorDto = _mapper.Map<AuthorDto>(author);

        return createdAuthorDto;
    }

    public async Task UpdateAsync(int id, AuthorForUpdateDto authorDto)
    {
        var authorToUpdate = await _unitOfWork.AuthorRepository.GetByIdAsync(id) ?? throw new NotFoundApiException();

        _mapper.Map(authorDto, authorToUpdate);

        _unitOfWork.AuthorRepository.Modify(authorToUpdate);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var authorToDelete = await _unitOfWork.AuthorRepository.GetByIdAsync(id) ?? throw new NotFoundApiException();

        _unitOfWork.AuthorRepository.Remove(authorToDelete);
        await _unitOfWork.SaveAsync();
    }
}
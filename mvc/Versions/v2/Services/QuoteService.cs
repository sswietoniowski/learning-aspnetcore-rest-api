using AutoMapper;

using mvc.Configurations.Exceptions;
using mvc.DataAccess.Entities;
using mvc.DataAccess.Repository.Interfaces;
using mvc.DTOs;
using mvc.Versions.v2.DTOs;

namespace mvc.Versions.v2.Services;

public class QuoteService : IQuoteService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public QuoteService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<QuoteDto>> GetAllAsync()
    {
        var (quotes, _) = await _unitOfWork.QuoteRepository.GetQuotesAsync();

        var quotesDto = _mapper.Map<IEnumerable<QuoteDto>>(quotes);

        return quotesDto;
    }

    public async Task<QuoteDto> GetByIdAsync(int id)
    {
        var quote = await _unitOfWork.QuoteRepository.GetByIdAsync(id) ?? throw new NotFoundApiException();

        var quoteDto = _mapper.Map<QuoteDto>(quote);

        return quoteDto;
    }

    public async Task<(IEnumerable<QuoteDto>, PaginationMetadata)> GetAsync(string? author = null, string? language = null, string? text = null, int pageNumber = 1, int pageSize = 10)
    {
        var (quotes, paginationMetadata) = await _unitOfWork.QuoteRepository.GetQuotesAsync(
            author, language, text, pageNumber, pageSize);
        var quotesDto = _mapper.Map<IEnumerable<QuoteDto>>(quotes);

        return (quotesDto, paginationMetadata);
    }

    public async Task<QuoteDto> CreateAsync(QuoteForCreationDto quoteDto)
    {
        var quote = _mapper.Map<Quote>(quoteDto);

        await _unitOfWork.QuoteRepository.AddAsync(quote);
        await _unitOfWork.SaveAsync();

        var createdQuoteDto = _mapper.Map<QuoteDto>(quote);

        return createdQuoteDto;
    }

    public async Task UpdateAsync(int id, QuoteForUpdateDto quoteDto)
    {
        var quoteToUpdate = await _unitOfWork.QuoteRepository.GetByIdAsync(id) ?? throw new NotFoundApiException();

        _mapper.Map(quoteDto, quoteToUpdate);

        _unitOfWork.QuoteRepository.Modify(quoteToUpdate);
        await _unitOfWork.SaveAsync();
    }

    public async Task<QuoteForUpdateDto> GetForUpdateAsync(int id)
    {
        var quoteToUpdate = await _unitOfWork.QuoteRepository.GetByIdAsync(id) ?? throw new NotFoundApiException();

        var quoteToUpdateDto = _mapper.Map<QuoteForUpdateDto>(quoteToUpdate);

        return quoteToUpdateDto;
    }

    public async Task UpdatePartiallyAsync(int id, QuoteForUpdateDto quoteToUpdateDto)
    {
        var quoteToUpdate = await _unitOfWork.QuoteRepository.GetByIdAsync(id) ?? throw new NotFoundApiException();

        _mapper.Map(quoteToUpdateDto, quoteToUpdate);

        _unitOfWork.QuoteRepository.Modify(quoteToUpdate);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var quoteToDelete = await _unitOfWork.QuoteRepository.GetByIdAsync(id) ?? throw new NotFoundApiException();

        _unitOfWork.QuoteRepository.Remove(quoteToDelete);
        await _unitOfWork.SaveAsync();
    }
}
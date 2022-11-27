using AutoMapper;

using minimal.Configurations.Exceptions;
using minimal.DataAccess.Entities;
using minimal.DataAccess.Repository.Interfaces;
using minimal.DTOs;

namespace minimal.Services;

public class QuotesService : IQuotesService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public QuotesService(IUnitOfWork unitOfWork, IMapper mapper)
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

    public async Task DeleteAsync(int id)
    {
        var quoteToDelete = await _unitOfWork.QuoteRepository.GetByIdAsync(id) ?? throw new NotFoundApiException();

        _unitOfWork.QuoteRepository.Remove(quoteToDelete);
        await _unitOfWork.SaveAsync();
    }
}
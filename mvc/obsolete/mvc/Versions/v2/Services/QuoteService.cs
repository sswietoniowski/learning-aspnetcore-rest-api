using AutoMapper;

using mvc.Configurations.Exceptions;
using mvc.DataAccess.Entities;
using mvc.DataAccess.Repository.Interfaces;
using mvc.DTOs;
using mvc.Versions.v2.DTOs;

namespace mvc.Versions.v2.Services;

public class QuoteService : Service<Quote, QuoteDto, QuoteForCreationDto, QuoteForUpdateDto, IQuoteRepository>, IQuoteService
{
    public QuoteService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
        Repository = unitOfWork.QuoteRepository;
    }

    public async Task<(IEnumerable<QuoteDto>, PaginationMetadata)> GetAsync(string? author = null, string? language = null, string? text = null, int pageNumber = 1, int pageSize = 10)
    {
        var (quotes, paginationMetadata) = await UnitOfWork.QuoteRepository.GetQuotesAsync(
            author, language, text, pageNumber, pageSize);
        var quotesDto = Mapper.Map<IEnumerable<QuoteDto>>(quotes);

        return (quotesDto, paginationMetadata);
    }

    public async Task<QuoteForUpdateDto> GetForUpdateAsync(int id)
    {
        var quoteToUpdate = await UnitOfWork.QuoteRepository.GetByIdAsync(id) ?? throw new NotFoundApiException();

        var quoteToUpdateDto = Mapper.Map<QuoteForUpdateDto>(quoteToUpdate);

        return quoteToUpdateDto;
    }

    public async Task UpdatePartiallyAsync(int id, QuoteForUpdateDto quoteToUpdateDto)
    {
        var quoteToUpdate = await UnitOfWork.QuoteRepository.GetByIdAsync(id) ?? throw new NotFoundApiException();

        Mapper.Map(quoteToUpdateDto, quoteToUpdate);

        UnitOfWork.QuoteRepository.Modify(quoteToUpdate);
        await UnitOfWork.SaveAsync();
    }
}
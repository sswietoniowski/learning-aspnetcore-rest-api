using AutoMapper;

using minimal.DTOs;
using minimal.Models;

namespace minimal.Configurations.Mapper;

public class QuoteProfile : Profile
{
    public QuoteProfile()
    {
        CreateMap<Quote, QuoteDto>().ReverseMap();
        CreateMap<QuoteForCreationDto, Quote>().ReverseMap();
        CreateMap<QuoteForUpdateDto, Quote>().ReverseMap();
    }
}
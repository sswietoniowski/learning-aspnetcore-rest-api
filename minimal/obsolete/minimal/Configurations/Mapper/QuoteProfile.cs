using AutoMapper;

using minimal.DataAccess.Entities;
using minimal.DTOs;

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
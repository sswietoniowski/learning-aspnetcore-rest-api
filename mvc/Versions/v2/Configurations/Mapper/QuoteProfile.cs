using AutoMapper;
using mvc.DataAccess.Entities;
using mvc.Versions.v2.DTOs;

namespace mvc.Versions.v2.Configurations.Mapper;

public class QuoteProfile : Profile
{
    public QuoteProfile()
    {
        CreateMap<Quote, QuoteDto>().ReverseMap();
        CreateMap<QuoteForCreationDto, Quote>();
        CreateMap<QuoteForUpdateDto, Quote>().ReverseMap();
    }
}
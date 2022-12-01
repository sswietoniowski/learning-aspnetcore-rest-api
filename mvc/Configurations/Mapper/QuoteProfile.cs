using AutoMapper;
using mvc.DataAccess.Entities;
using mvc.Versions.v1.DTOs;

namespace mvc.Configurations.Mapper;

public class QuoteProfile : Profile
{
    public QuoteProfile()
    {
        CreateMap<Quote, QuoteDto>()
            .ForMember(d => d.Author, opt => opt.MapFrom(src => (src.Author != null) ? src.Author.Name : null))
            .ForMember(d => d.Language, opt => opt.MapFrom(src => (src.Language != null) ? src.Language.Name : null))
            .ReverseMap();
        CreateMap<QuoteForCreationDto, Quote>().ReverseMap();
        CreateMap<QuoteForUpdateDto, Quote>().ReverseMap();
    }
}
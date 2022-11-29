using AutoMapper;
using mvc.DataAccess.Entities;
using mvc.DTOs;

namespace mvc.Configurations.Mapper;

public class QuoteProfile : Profile
{
    public QuoteProfile()
    {
        CreateMap<Quote, QuoteDto>()
            .ForMember(d => d.Author, opt => opt.MapFrom(src => (src.Author != null) ? src.Author.Name : string.Empty))
            .ForMember(d => d.Language, opt => opt.MapFrom(src => (src.Language != null) ? src.Language.Name : string.Empty))
            .ReverseMap();
        CreateMap<QuoteForCreationDto, Quote>().ReverseMap();
        CreateMap<QuoteForUpdateDto, Quote>().ReverseMap();
    }
}
using AutoMapper;
using mvc.DataAccess.Entities;
using mvc.Versions.v1.DTOs;

namespace mvc.Versions.v1.Configurations.Mapper;

public class QuoteProfile : Profile
{
    public QuoteProfile()
    {
        CreateMap<Quote, QuoteDto>()
            .ForMember(d => d.Author, opt =>
                opt.MapFrom(src => (src.Author != null) ? src.Author.Name : null))
            .ForMember(d => d.Language, opt =>
                opt.MapFrom(src => (src.Language != null) ? src.Language.Name : null))
            .ReverseMap();
        CreateMap<QuoteForCreationDto, Quote>()
            .ForMember(d => d.Author, opt => opt.Ignore())
            .ForMember(d => d.Language, opt => opt.Ignore());
        CreateMap<QuoteForUpdateDto, Quote>()
            .ForMember(d => d.Author, opt => opt.Ignore())
            .ForMember(d => d.Language, opt => opt.Ignore());
        CreateMap<Quote, QuoteForUpdateDto>()
            .ForMember(d => d.Author, opt =>
                opt.MapFrom(src => (src.Author != null) ? src.Author.Name : null))
            .ForMember(d => d.Language, opt =>
                opt.MapFrom(src => (src.Language != null) ? src.Language.Name : null));
    }
}
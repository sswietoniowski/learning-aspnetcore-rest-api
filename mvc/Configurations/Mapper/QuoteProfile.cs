using AutoMapper;
using mvc.DataAccess.Entities;
using mvc.DTOs;

namespace mvc.Configurations.Mapper;

public class QuoteProfile : Profile
{
    public QuoteProfile()
    {
        CreateMap<QuoteEntity, QuoteDto>().ReverseMap();
        CreateMap<QuoteForCreationDto, QuoteEntity>().ReverseMap();
        CreateMap<QuoteForUpdateDto, QuoteEntity>().ReverseMap();
    }
}
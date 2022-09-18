using AutoMapper;

using minimal.DataAccess.Entities;
using minimal.DTOs;

namespace minimal.Configurations.Mapper;

public class QuoteProfile : Profile
{
    public QuoteProfile()
    {
        CreateMap<QuoteEntity, QuoteDto>().ReverseMap();
        CreateMap<QuoteForCreationDto, QuoteEntity>().ReverseMap();
        CreateMap<QuoteForUpdateDto, QuoteEntity>().ReverseMap();
    }
}
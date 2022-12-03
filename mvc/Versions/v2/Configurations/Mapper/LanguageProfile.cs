using AutoMapper;
using mvc.DataAccess.Entities;
using mvc.Versions.v2.DTOs;

namespace mvc.Versions.v2.Configurations.Mapper;

public class LanguageProfile : Profile
{
    public LanguageProfile()
    {
        CreateMap<Language, LanguageDto>().ReverseMap();
    }
}
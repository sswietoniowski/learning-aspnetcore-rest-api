using AutoMapper;
using mvc.DataAccess.Entities;
using mvc.Versions.v2.DTOs;

namespace mvc.Versions.v2.Configurations.Mapper;

public class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        CreateMap<Author, AuthorDto>().ReverseMap();
    }
}
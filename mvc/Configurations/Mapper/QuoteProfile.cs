﻿using AutoMapper;
using mvc.DataAccess.Entities;
using mvc.DTOs;

namespace mvc.Configurations.Mapper;

public class QuoteProfile : Profile
{
    public QuoteProfile()
    {
        CreateMap<Quote, QuoteDto>().ReverseMap();
        CreateMap<QuoteForCreationDto, Quote>().ReverseMap();
        CreateMap<QuoteForUpdateDto, Quote>().ReverseMap();
    }
}
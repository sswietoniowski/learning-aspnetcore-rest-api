using AutoMapper;
using mvc.DTOs;
using mvc.Models;

namespace mvc.Configurations.Mapper
{
    public class QuoteProfile : Profile
    {
        public QuoteProfile()
        {
            CreateMap<Quote, QuoteDto>().ReverseMap();
            CreateMap<CreateQuoteDto, Quote>().ReverseMap();
            CreateMap<UpdateQuoteDto, Quote>().ReverseMap();
        }
    }
}

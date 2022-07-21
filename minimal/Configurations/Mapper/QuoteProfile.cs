using AutoMapper;

using minimal.DTOs;
using minimal.Models;

namespace minimal.Configurations.Mapper
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

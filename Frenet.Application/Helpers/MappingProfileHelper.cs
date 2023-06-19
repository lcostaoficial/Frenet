using AutoMapper;
using Frenet.Application.Models.Dto;
using Frenet.Application.Models.Entities;
using Frenet.Application.Models.ViewModel;

namespace Frenet.Application.Helpers
{
    public class MappingProfileHelper : Profile
    {
        public MappingProfileHelper()
        {
            CreateMap<ShippingQuoteDto, ShippingQuoteVm>().ReverseMap();
            CreateMap<ShippingItemArrayDto, ShippingItemArrayVm>().ReverseMap();
            CreateMap<ShippingSevicesArrayDto, QuoteHistory>().ReverseMap();
        }
    }
}
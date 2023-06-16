using Frenet.Application.Models.Dto;

namespace Frenet.Application.Services.Interfaces
{
    public interface IShippingService
    {
        Task<ShippingQuoteResponseDto>? Quote(ShippingQuoteDto shippingQuote);
    }
}
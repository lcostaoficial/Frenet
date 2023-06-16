namespace Frenet.Application.Models.Dto
{
    public class ShippingQuoteResponseDto
    {
        public List<ShippingSevicesArrayDto>? ShippingSevicesArray { get; set; }
        public int? Timeout { get; set; }

    }
}
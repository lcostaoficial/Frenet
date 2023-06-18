using System.Text.Json.Serialization;

namespace Frenet.Application.Models.Dto
{
    public class ShippingQuoteResponseDto
    {
        public List<ShippingSevicesArrayDto>? ShippingSevicesArray { get; set; }

        public string? Message { get; set; }

        public int? Timeout { get; set; }
    }
}
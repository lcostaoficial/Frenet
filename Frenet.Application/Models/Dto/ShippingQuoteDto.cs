namespace Frenet.Application.Models.Dto
{
    public class ShippingQuoteDto
    {
        public string? SellerCEP { get; set; }
        public string? RecipientCEP { get; set; }
        public double? ShipmentInvoiceValue { get; set; }
        public string? ShippingServiceCode { get; set; }
        public List<ShippingItemArrayDto>? ShippingItemArray { get; set; }
        public string? RecipientCountry { get; set; }
    }
}
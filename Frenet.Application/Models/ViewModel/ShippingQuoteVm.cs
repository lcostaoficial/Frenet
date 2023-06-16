namespace Frenet.Application.Models.ViewModel
{
    public class ShippingQuoteVm
    {
        public string? SellerCEP { get; set; }
        public string? RecipientCEP { get; set; }
        public double? ShipmentInvoiceValue { get; set; }
        public string? ShippingServiceCode { get; set; }
        public List<ShippingItemArrayVm>? ShippingItemArray { get; set; }
        public string? RecipientCountry { get; set; }
    }
}
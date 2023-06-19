namespace Frenet.Domain.Entities
{
    public class QuoteHistory
    {
        public int Id { get; set; }
        public string Carrier { get; set; }
        public string CarrierCode { get; set; }
        public int DeliveryTime { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceDescription { get; set; }
        public decimal ShippingPrice { get; set; }
        public int OriginalDeliveryTime { get; set; }
        public decimal OriginalShippingPrice { get; set; }
    }
}
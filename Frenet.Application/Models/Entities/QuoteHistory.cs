namespace Frenet.Application.Models.Entities
{
    public class QuoteHistory
    {
        public int Id { get; set; }
        public string? SellerCEP { get; set; }
        public string? Carrier { get; set; }
        public string? CarrierCode { get; set; }
        public string? DeliveryTime { get; set; }
        public string? ServiceCode { get; set; }
        public string? ServiceDescription { get; set; }
        public string? ShippingPrice { get; set; }
        public string? OriginalDeliveryTime { get; set; }
        public string? OriginalShippingPrice { get; set; }
        public DateTime CreationDate { get; set; }

        public void GerarDataDeCriacao()
        {
            CreationDate = DateTime.Now;
        }

        public void InserirSellerCEP(string sellerCep)
        {
            SellerCEP = sellerCep;
        }
    }
}
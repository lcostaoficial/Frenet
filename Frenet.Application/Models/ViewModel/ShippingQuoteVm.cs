using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Frenet.Application.Models.ViewModel
{
    public class ShippingQuoteVm
    {
        [Display(Name = "CEP de origem")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string? SellerCEP { get; set; }

        [Display(Name = "CEP de destino")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string? RecipientCEP { get; set; }

        [Display(Name = "Valor da Fatura")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public double? ShipmentInvoiceValue { get; set; }

        [Display(Name = "Serviço")]
        public string? ShippingServiceCode { get; set; }

        public List<ShippingItemArrayVm>? ShippingItemArray { get; set; }

        public string? RecipientCountry { get; set; }
    }
}
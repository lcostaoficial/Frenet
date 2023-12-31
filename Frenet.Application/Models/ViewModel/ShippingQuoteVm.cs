﻿using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Valor da Fatura (R$)")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public double? ShipmentInvoiceValue { get; set; }

        [Display(Name = "Serviço")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string? ShippingServiceCode { get; set; }

        public List<ShippingItemArrayVm>? ShippingItemArray { get; set; }

        public string? ContentJson { get; set; }
    }
}
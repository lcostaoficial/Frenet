using System.ComponentModel.DataAnnotations;

namespace Frenet.Application.Models.ViewModel
{
    public class ShippingItemArrayVm
    {
        [Display(Name = "Altura")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int? Height { get; set; }

        [Display(Name = "Comprimento")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int? Length { get; set; }

        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int? Quantity { get; set; }

        [Display(Name = "Peso")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public double? Weight { get; set; }

        [Display(Name = "Largura")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int? Width { get; set; }

        public string? SKU { get; set; }

        [Display(Name = "Categoria")]
        public string? Category { get; set; }

        public string? ContentJson { get; set; }
    }
}
using Frenet.Application.Models.Dto;
using Frenet.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Frenet.Application.Controllers
{
    public class ShippingController : Controller
    {
        private readonly ShippingService _shippingService;

        public ShippingController()
        {
            _shippingService = new ShippingService();
        }

        public async Task<IActionResult> Quote()
        {
            var services = await _shippingService.Info();

            ViewBag.Services = services.ShippingSeviceAvailableArray!.OrderBy(x => x.Carrier).Select(service => new SelectListItem()
            {
                Text = $"{service.Carrier} - {service.ServiceDescription}",
                Value = service.ServiceCode
            });

            //var teste = new ShippingQuoteDto();

            //teste.SellerCEP = "04757020";
            //teste.RecipientCEP = "14270000";
            //teste.ShipmentInvoiceValue = 320.685;
            //teste.ShippingServiceCode = null;

            //teste.ShippingItemArray = new List<ShippingItemArrayDto>
            //{
            //    new ShippingItemArrayDto
            //    {
            //        Height = 2,
            //        Length = 33,
            //        Quantity = 1,
            //        Weight = 1.18,
            //        Width = 47,
            //        SKU = "SKU",
            //        Category = "Running"
            //    },
            //    new ShippingItemArrayDto
            //    {
            //        Height = 5,
            //        Length = 15,
            //        Quantity = 1,
            //        Weight = 0.15,
            //        Width = 29
            //    }
            //};

            //var response = await _shippingService.Quote(teste);

            return View();
        }
    }
}
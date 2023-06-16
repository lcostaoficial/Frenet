using Frenet.Application.Models.ViewModel;
using Frenet.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Frenet.Application.Controllers
{
    public class ShippingController : Controller
    {
        private readonly IShippingService _shippingService;

        public ShippingController(IShippingService shippingService)
        {
            _shippingService = shippingService;
        }       

        public async Task<IActionResult> Quote()
        {
            var services = await _shippingService.Info();

            ViewBag.Services = services.ShippingSeviceAvailableArray!.OrderBy(x => x.Carrier).Select(service => new SelectListItem()
            {
                Text = $"{service.Carrier} - {service.ServiceDescription}",
                Value = service.ServiceCode
            });

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Quote(ShippingQuoteVm model)
        {
            return null;
        }
    }
}
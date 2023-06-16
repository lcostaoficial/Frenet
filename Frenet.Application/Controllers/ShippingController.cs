using Frenet.Application.Models.ViewModel;
using Frenet.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

namespace Frenet.Application.Controllers
{
    public class ShippingController : Controller
    {
        private readonly IShippingService _shippingService;

        public ShippingController(IShippingService shippingService)
        {
            _shippingService = shippingService;
        }

        public IActionResult AtualizarItens(string contentJson)
        {
            var contentList = JsonSerializer.Deserialize<List<ShippingItemArrayVm>>(contentJson);
            return PartialView("_ListaDeItensDeEnvio", contentList);
        }

        [HttpPost]
        public IActionResult AdicionarItem(ShippingItemArrayVm item)
        {
            var contentList = JsonSerializer.Deserialize<List<ShippingItemArrayVm>>(item.ContentJson!);

            contentList!.Add(item);

            return Json(new
            {
                ContentList = JsonSerializer.Serialize(contentList)
            });
        }

        public IActionResult RemoverItem(int index, string contentJson)
        {
            var contentList = JsonSerializer.Deserialize<List<ShippingItemArrayVm>>(contentJson);

            contentList!.RemoveAt(index);

            return Json(new
            {
                ContentList = JsonSerializer.Serialize(contentList)
            });
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
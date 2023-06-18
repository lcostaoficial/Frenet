using AutoMapper;
using Frenet.Application.Models.Dto;
using Frenet.Application.Models.ViewModel;
using Frenet.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Frenet.Application.Controllers
{
    public class ShippingController : Controller
    {
        private readonly IShippingService _shippingService;
        private readonly IMapper _mapper;

        public ShippingController(IShippingService shippingService, IMapper mapper)
        {
            _shippingService = shippingService;
            _mapper = mapper;
        }

        public IActionResult AtualizarItens(string contentJson)
        {
            var contentList = JsonSerializer.Deserialize<List<ShippingItemArrayVm>>(contentJson);
            return PartialView("_ListaDeItensDeEnvio", contentList);
        }

        [HttpPost]
        public IActionResult AdicionarItem(ShippingItemArrayVm item)
        {
            if (ModelState.IsValid)
            {
                var contentList = JsonSerializer.Deserialize<List<ShippingItemArrayVm>>(item.ContentJson!);
                contentList!.Add(item);
                return Json(new { ContentList = JsonSerializer.Serialize(contentList) });
            }
            else
            {
                return Json(new { Error = "Preencha os campos corretamente!" });
            }
        }

        public IActionResult RemoverItem(int index, string contentJson)
        {
            var contentList = JsonSerializer.Deserialize<List<ShippingItemArrayVm>>(contentJson);

            contentList!.RemoveAt(index);

            return Json(new { ContentList = JsonSerializer.Serialize(contentList) });
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

        public IActionResult QuoteResult(string contentJson)
        {
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var response = JsonSerializer.Deserialize<ShippingQuoteResponseDto>(contentJson, jsonOptions);

            return PartialView("_ResultadoDaCotacao", response);
        }

        [HttpPost]
        public async Task<IActionResult> Quote(ShippingQuoteVm model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var contentList = JsonSerializer.Deserialize<List<ShippingItemArrayVm>>(model.ContentJson!);

                    if (!contentList!.Any())
                        return Json(new { Error = "Os itens são obrigatórios!" });

                    if (!Regex.IsMatch(model.SellerCEP!, @"^\d+$") || !Regex.IsMatch(model.RecipientCEP!, @"^\d+$"))
                        return Json(new { Error = "Os campos de CEP aceitam somente número" });

                    model.ShippingItemArray = contentList;

                    var shippingQuoteDto = _mapper.Map<ShippingQuoteDto>(model);

                    var result = await _shippingService.Quote(shippingQuoteDto)!;

                    return Json(new { Response = result });
                }
                else
                {
                    return Json(new { Error = "Preencha os campos corretamente!" });
                }
            }
            catch (Exception e)
            {
                return Json(new { Error = e.Message });
            }
        }
    }
}
﻿using AutoMapper;
using Frenet.Application.Models.Dto;
using Frenet.Application.Models.Entities;
using Frenet.Application.Models.ViewModel;
using Frenet.Application.Repositories.Interfaces;
using Frenet.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Frenet.Application.Controllers
{
    public class ShippingController : Controller
    {
        private readonly IQuoteHistoryRepository _quoteHistoryRepository;
        private readonly IShippingService _shippingService;
        private readonly IMapper _mapper;

        public ShippingController(IQuoteHistoryRepository quoteHistoryRepository, IShippingService shippingService, IMapper mapper)
        {
            _quoteHistoryRepository = quoteHistoryRepository;
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

        public async Task<IActionResult> QuoteHistory(string sellerCEP)
        {
            try
            {
                if (string.IsNullOrEmpty(sellerCEP))
                    return Json(new { Error = "CEP de origem é necessário para consultar histórico" });

                var result = await _quoteHistoryRepository.GetLast10QuoteHistories(sellerCEP);

                if (result == null && !result!.Any())
                    return Json(new { Error = "Sem histórico de movimentação para o CEP de origem informado" });

                return Json(new { ContentList = JsonSerializer.Serialize(result) });
            }
            catch (Exception e)
            {
                return Json(new { Error = e.Message });
            }
        }

        public IActionResult HistoryModal(string contentJson)
        {
            var response = JsonSerializer.Deserialize<List<QuoteHistory>>(contentJson);

            return PartialView("_HistoricoDeCotacao", response);
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

                    if (result!.ShippingSevicesArray!.Any())
                    {
                        foreach (var item in result!.ShippingSevicesArray!)
                        {
                            if (!item.Error)
                            {
                                var quoteHistory = _mapper.Map<QuoteHistory>(item);

                                quoteHistory.InserirSellerCEP(model!.SellerCEP!);

                                quoteHistory.GerarDataDeCriacao();

                                await _quoteHistoryRepository.AddQuoteHistory(quoteHistory);
                            }
                        }
                    }

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
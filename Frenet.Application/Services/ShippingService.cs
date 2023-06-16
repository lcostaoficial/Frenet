using Frenet.Application.Models.Dto;
using Frenet.Application.Services.Interfaces;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace Frenet.Application.Services
{
    public class ShippingService : IShippingService
    {
        private const string token = "1E3857BAR657CR4A69R8A72RF4DFE0A7831F";

        public async Task<ShippingInfoDto> Info()
        {
            var responseObject = new ShippingInfoDto();

            try
            {
                var _httpClient = new HttpClient();

                string url = "https://api.frenet.com.br/shipping/info";

                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    responseObject = JsonSerializer.Deserialize<ShippingInfoDto>(responseBody);

                    return responseObject!;
                }
                else
                {
                    Debug.WriteLine("Erro na requisição: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Ocorreu um erro na requisição: " + ex.Message);
            }

            return responseObject!;
        }

        public async Task<ShippingQuoteResponseDto> Quote(ShippingQuoteDto shippingQuote)
        {
            var responseObject = new ShippingQuoteResponseDto();

            try
            {
                var _httpClient = new HttpClient();

                var request = new HttpRequestMessage(HttpMethod.Post, "https://api.frenet.com.br/shipping/quote");

                request.Headers.Add("Accept", "application/json");
                request.Headers.Add("token", token);

                var content = new StringContent(JsonSerializer.Serialize(shippingQuote), Encoding.UTF8, "application/json");

                request.Content = content;

                HttpResponseMessage response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    responseObject = JsonSerializer.Deserialize<ShippingQuoteResponseDto>(responseBody);

                    return responseObject!;
                }
                else
                {
                    Debug.WriteLine("Erro na requisição: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Ocorreu um erro na requisição: " + ex.Message);
            }

            return responseObject!;
        }
    }
}
using Shopping.Aggregator.Mobile.DTOs;
using Shopping.Aggregator.Mobile.Extensions;
using Shopping.Aggregator.Mobile.Interfaces;
using Shopping.Aggregator.Mobile.Models;

namespace Shopping.Aggregator.Mobile.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<BasketDto> GetBasket(string userName)
        {
            var response = await _httpClient.GetAsync($"{ApiSettings.Catalog.BasePath}/{userName}");

            return await response.ReadContentAs<BasketDto>();
        }
    }
}

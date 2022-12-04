using Shopping.Aggregator.Web.DTOs;
using Shopping.Aggregator.Web.Extensions;
using Shopping.Aggregator.Web.Interfaces;
using Shopping.Aggregator.Web.Models;

namespace Shopping.Aggregator.Web.Services
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

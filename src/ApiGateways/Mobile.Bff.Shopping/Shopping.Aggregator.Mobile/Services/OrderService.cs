using Shopping.Aggregator.Mobile.DTOs;
using Shopping.Aggregator.Mobile.Extensions;
using Shopping.Aggregator.Mobile.Interfaces;
using Shopping.Aggregator.Mobile.Models;

namespace Shopping.Aggregator.Mobile.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<OrderResponseDto>> GetOrdersByUserName(string userName)
        {
            var response = await _httpClient.GetAsync($"{ApiSettings.Ordering.BasePath}/{userName}");

            return await response.ReadContentAs<IEnumerable<OrderResponseDto>>();
        }
    }
}

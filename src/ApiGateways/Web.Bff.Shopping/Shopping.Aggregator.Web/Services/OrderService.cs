using Shopping.Aggregator.Web.DTOs;
using Shopping.Aggregator.Web.Extensions;
using Shopping.Aggregator.Web.Interfaces;
using Shopping.Aggregator.Web.Models;

namespace Shopping.Aggregator.Web.Services
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

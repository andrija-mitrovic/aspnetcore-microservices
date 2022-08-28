using Shopping.Aggregator.Mobile.DTOs;

namespace Shopping.Aggregator.Mobile.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponseDto>> GetOrdersByUserName(string userName);
    }
}

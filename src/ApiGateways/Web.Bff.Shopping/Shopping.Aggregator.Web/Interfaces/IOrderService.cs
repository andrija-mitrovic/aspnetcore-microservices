using Shopping.Aggregator.Web.DTOs;

namespace Shopping.Aggregator.Web.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponseDto>> GetOrdersByUserName(string userName);
    }
}

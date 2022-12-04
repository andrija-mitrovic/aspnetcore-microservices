using Shopping.Aggregator.Web.DTOs;

namespace Shopping.Aggregator.Web.Interfaces
{
    public interface IBasketService
    {
        Task<BasketDto> GetBasket(string userName);
    }
}

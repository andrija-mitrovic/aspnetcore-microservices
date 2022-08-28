using Shopping.Aggregator.Mobile.DTOs;

namespace Shopping.Aggregator.Mobile.Interfaces
{
    public interface IBasketService
    {
        Task<BasketDto> GetBasket(string userName);
    }
}

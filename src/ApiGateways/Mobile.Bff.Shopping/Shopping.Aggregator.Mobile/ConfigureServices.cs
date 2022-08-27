using Shopping.Aggregator.Mobile.Interfaces;
using Shopping.Aggregator.Mobile.Models;
using Shopping.Aggregator.Mobile.Services;

namespace Shopping.Aggregator.Mobile
{
    public static class ConfigureServices
    {
        private static ApiSettings ApiSettings { get; set; } = new ApiSettings();

        public static IServiceCollection AddShoppingAggregatorMobileServices(this IServiceCollection services, IConfiguration configuration)
        {
            configuration.GetSection(nameof(ApiSettings)).Bind(ApiSettings);

            services.AddHttpClient<ICatalogService, CatalogService>(x =>
                x.BaseAddress = new Uri(configuration[ApiSettings.Catalog.Url]));

            services.AddHttpClient<IBasketService, BasketService>(x =>
                x.BaseAddress = new Uri(configuration[ApiSettings.Basket.Url]));

            services.AddHttpClient<IOrderService, OrderService>(x =>
                x.BaseAddress = new Uri(configuration[ApiSettings.Ordering.Url]));

            services.AddControllers();

            return services;
        }
    }
}

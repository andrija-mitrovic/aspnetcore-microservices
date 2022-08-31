using Shopping.Aggregator.Web.Interfaces;
using Shopping.Aggregator.Web.Models;
using Shopping.Aggregator.Web.Services;

namespace Shopping.Aggregator.Web
{
    public static class ConfigureServices
    {
        public static ApiSettings ApiSettings { get; set; } = new ApiSettings();

        public static IServiceCollection AddShoppingAggregatorWebServices(this IServiceCollection services, IConfiguration configuration)
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

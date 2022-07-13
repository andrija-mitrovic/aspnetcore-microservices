using Basket.API.Constants;
using Basket.API.GrpcServices;
using Basket.API.Repositories;
using Discount.Grpc.Protos;
using MassTransit;

namespace Basket.API
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddBasketAPIServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Redis Configuration
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration[AppConstants.REDIS_CONNECTION_STRING];
            });

            //Grpc Configuration
            services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>
                (opt => opt.Address = new Uri(configuration[AppConstants.GRPC_DISCOUNT_SETTINGS]));

            services.AddControllers();

            //General Configuration
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<IDiscountGrpcService, DiscountGrpcService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            //MassTransit-RabbitMQ Configuration
            services.AddMassTransit(config =>
            {
                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(configuration[AppConstants.EVENT_BUS_HOST_ADDRESS]);
                });
            });

            services.AddMassTransitHostedService();

            services.AddHealthChecks().AddRedis(configuration[AppConstants.REDIS_CONNECTION_STRING], name: "Redis");

            return services;
        }
    }
}

using Event.Messages.Constants;
using MassTransit;
using Ordering.API.EventBusConsumer;
using Ordering.API.Services;
using Ordering.Application.Common.Constants;
using Ordering.Application.Common.Interfaces;
using Ordering.Infrastructure.Persistence;

namespace Ordering.API
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddAPIServices(this IServiceCollection services, IConfiguration configuration)
        {
            //General Configuration
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<BasketCheckoutConsumer>();

            services.AddControllers();

            services.AddHealthChecks().AddDbContextCheck<ApplicationDbContext>();

            services.AddSingleton<ICurrentUserService, CurrentUserService>();

            services.AddHttpContextAccessor();

            //MassTransit-RabbitMQ Configuration
            services.AddMassTransit(config =>
            {
                config.AddConsumer<BasketCheckoutConsumer>();
                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(configuration[AppConstants.EVENT_BUS_HOST_ADDRESS]);

                    cfg.ReceiveEndpoint(EventBusConstants.BASKET_CHECKOUT_QUEUE, x =>
                    {
                        x.ConfigureConsumer<BasketCheckoutConsumer>(ctx);
                    });
                });
            });

            services.AddMassTransitHostedService();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}

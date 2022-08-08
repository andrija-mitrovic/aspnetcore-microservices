using Discount.Grpc.Constants;
using Discount.Grpc.Repositories;

namespace Discount.Grpc
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddDiscountGrpcServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddGrpc();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IDiscountRepository, DiscountRepository>();

            return services;
        }
    }
}

using Discount.API.Constants;
using Discount.API.Repositories;

namespace Discount.API
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddDiscountAPIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            services.AddScoped<IDiscountRepository, DiscountRepository>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddHealthChecks().AddNpgSql(configuration[AppConstants.POSTGRES_DATABASE_CONNECTION], name: "PostgreSql");

            return services;
        }
    }
}

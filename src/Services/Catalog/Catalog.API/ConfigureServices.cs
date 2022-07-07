using Catalog.API.Data;
using Catalog.API.Helpers;
using Catalog.API.Models;
using Catalog.API.Repositories;

namespace Catalog.API
{
    public static class ConfigureServices
    {
        private const string HEALTH_CHECK_NAME = "MongoDBConnectionCheck";
        public static SerilogSettings SerilogSettings { get; set; } = new SerilogSettings();

        public static IServiceCollection AddCatalogAPIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            configuration.GetSection(SerilogSettings.SectionName).Bind(SerilogSettings);
            services.Configure<MongoSettings>(configuration.GetSection(MongoSettings.SectionName));

            services.AddScoped<ICatalogContext, CatalogContext>();
            services.AddScoped<IProductRepository, ProductRepository>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddHealthChecks().AddCheck<MongoHealthCheck>(HEALTH_CHECK_NAME);

            return services;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Common.Constants;
using Ordering.Application.Common.Interfaces;
using Ordering.Application.Common.Models;
using Ordering.Infrastructure.Persistence;
using Ordering.Infrastructure.Persistence.Interceptors;
using Ordering.Infrastructure.Persistence.Repositories;
using Ordering.Infrastructure.Services;

namespace Ordering.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString(AppConstants.MSSQL_DATABASE_CONNECTION)));

            services.AddScoped<AuditableEntitySaveChangesInterceptor>();
            services.AddScoped<ApplicationDbContextInitialiser>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IEmailService, EmailService>();

            services.Configure<EmailSettings>(x => configuration.GetSection(EmailSettings.SectionName));

            return services;
        }
    }
}

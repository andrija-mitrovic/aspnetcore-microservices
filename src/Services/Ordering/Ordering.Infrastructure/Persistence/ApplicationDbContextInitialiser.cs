using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ordering.Application.Common.Helpers;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistence
{
    public class ApplicationDbContextInitialiser
    {
        private readonly ILogger<ApplicationDbContextInitialiser> _logger;
        private readonly ApplicationDbContext _context;

        public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                if (_context.Database.IsSqlServer())
                {
                    await _context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{HelperFunctions.GetMethodName()} - An error occurred while initialising the database.");
                throw;
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"{HelperFunctions.GetMethodName()} - An error occurred while seeding the database.");
                throw;
            }
        }

        private async Task TrySeedAsync()
        {
            // Default data
            // Seed, if necessary
            if (!_context.Orders.Any())
            {
                await _context.Orders.AddRangeAsync(GetPreconfiguredOrders());
                await _context.SaveChangesAsync();

                _logger.LogInformation("Seed database associated with context {DbContextName}", typeof(ApplicationDbContext).Name);
            }
        }

        private IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order()
                {
                    UserName = "swn",
                    FirstName = "Andrija",
                    LastName = "Mitrovic",
                    EmailAddress = "andrija@gmail.com",
                    AddressLine = "Herceg Novi",
                    Country = "Montenegro",
                    TotalPrice = 350
                }
            };
        }
    }
}

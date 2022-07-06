using Catalog.API.Models;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.API.Helpers
{
    public class MongoHealthCheck : IHealthCheck
    {
        private IMongoDatabase _db { get; set; }
        public MongoClient _mongoClient { get; set; }
        private readonly ILogger<MongoHealthCheck> _logger;

        public MongoHealthCheck(IOptions<MongoSettings> configuration, ILogger<MongoHealthCheck> logger)
        {
            _mongoClient = new MongoClient(configuration.Value.ConnectionString);

            _db = _mongoClient.GetDatabase(configuration.Value.DatabaseName);

            _logger = logger;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {

            var healthCheckResultHealthy = await CheckMongoDBConnectionAsync();

            string message;

            if (healthCheckResultHealthy)
            {
                message = "MongoDB health check success";
                _logger.LogInformation($"{HelperFunctions.GetMethodName()} - {message}");
                return HealthCheckResult.Healthy(message);
            }

            message = "MongoDB health check success";
            _logger.LogError($"{HelperFunctions.GetMethodName()} - {message}");
            return HealthCheckResult.Unhealthy(message); ;
        }

        private async Task<bool> CheckMongoDBConnectionAsync()
        {
            try
            {
                await _db.RunCommandAsync((Command<BsonDocument>)"{ping:1}");
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}

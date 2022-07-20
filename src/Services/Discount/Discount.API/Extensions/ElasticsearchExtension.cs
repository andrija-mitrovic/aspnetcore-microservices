using Discount.API.Constants;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;

namespace Discount.API.Extensions
{
    public static class ElasticsearchExtension
    {
        public static void AddElasticsearch(this WebApplicationBuilder builder)
        {
            LoggerConfigure();

            builder.Host.UseSerilog();
        }

        private static void LoggerConfigure()
        {
            var environmentName = Environment.GetEnvironmentVariable(AppConstants.ENVIRONMENT);
            IConfigurationRoot configuration = ReturnConfigurationRoot(environmentName!);

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .WriteTo.Debug()
                .WriteTo.Console()
                .WriteTo.Elasticsearch(ConfigureElasticSink(environmentName!, configuration))
                .Enrich.WithProperty("Environment", environmentName)
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }

        private static IConfigurationRoot ReturnConfigurationRoot(string environmentName)
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .Build();
        }

        private static ElasticsearchSinkOptions ConfigureElasticSink(string environmentName, IConfiguration configuration)
        {
            var minimumLogLevel = configuration.GetValue<string>(AppConstants.ELASTIC_SEARCH_LOG_LEVEL);
            var esUri = configuration.GetValue<string>(AppConstants.ELASTIC_SEARCH_URI);

            _ = Enum.TryParse(minimumLogLevel, out LogEventLevel logEventLevel);

            return new ElasticsearchSinkOptions(new Uri(esUri))
            {
                AutoRegisterTemplate = true,
                IndexFormat = ReturnIndexFormat(environmentName),
                MinimumLogEventLevel = logEventLevel
            };
        }

        private static string ReturnIndexFormat(string environmentName) =>
            $"{Assembly.GetExecutingAssembly().GetName().Name?.ToLower().Replace(".", "-")}-" +
            $"{environmentName?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}";
    }
}

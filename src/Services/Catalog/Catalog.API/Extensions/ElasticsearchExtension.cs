using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;

namespace Catalog.API.Extensions
{
    public static class ElasticsearchExtension
    {
        private const string ENVIRONMENT = "ASPNETCORE_ENVIRONMENT";

        public static void AddElasticsearch(this WebApplicationBuilder builder)
        {
            LoggerConfigure();

            builder.Host.UseSerilog();
        }

        private static void LoggerConfigure()
        {
            var environmentName = Environment.GetEnvironmentVariable(ENVIRONMENT);
            IConfigurationRoot configuration = ReturnConfigurationRoot(environmentName!);

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .WriteTo.Debug()
                .WriteTo.Console()
                .WriteTo.Elasticsearch(ConfigureElasticSink(environmentName!))
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

        private static ElasticsearchSinkOptions ConfigureElasticSink(string environmentName)
        {
            _ = Enum.TryParse(ConfigureServices.SerilogSettings.MinLevel.Default, out LogEventLevel logEventLevel);

            return new ElasticsearchSinkOptions(new Uri(ConfigureServices.SerilogSettings.ElasticSearch.Uri))
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

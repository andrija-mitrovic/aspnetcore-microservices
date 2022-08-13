namespace Ordering.Application.Common.Constants
{
    public class AppConstants
    {
        public const string MSSQL_DATABASE_CONNECTION = "MssqlConnectionString";
        public const string EVENT_BUS_HOST_ADDRESS = "EventBusSettings:HostAddress";
        public const string ENVIRONMENT = "ASPNETCORE_ENVIRONMENT";
        public const string ELASTIC_SEARCH_LOG_LEVEL = "Serilog:MinimumLevel:Default";
        public const string ELASTIC_SEARCH_URI = "Serilog:ElasticSearch:Uri";
    }
}

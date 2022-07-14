namespace Discount.API.Constants
{
    public class AppConstants
    {
        public const string POSTGRES_DATABASE_CONNECTION = "DatabaseSettings:ConnectionString";
        public const string ENVIRONMENT = "ASPNETCORE_ENVIRONMENT";
        public const string ELASTIC_SEARCH_LOG_LEVEL = "Serilog:MinimumLevel:Default";
        public const string ELASTIC_SEARCH_URI = "Serilog:ElasticSearch:Uri";
    }
}

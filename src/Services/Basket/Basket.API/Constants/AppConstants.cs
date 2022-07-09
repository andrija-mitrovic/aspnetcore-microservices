namespace Basket.API.Constants
{
    public class AppConstants
    {
        public const string ENVIRONMENT = "ASPNETCORE_ENVIRONMENT";
        public const string GRPC_DISCOUNT_SETTINGS = "GrpcSettings:DiscountUrl";
        public const string ELASTIC_SEARCH_LOG_LEVEL = "Serilog:MinimumLevel:Default";
        public const string ELASTIC_SEARCH_URI = "Serilog:ElasticSearch:Uri";
        public const string REDIS_CONNECTION_STRING = "CacheSettings:ConnectionString";
        public const string EVENT_BUS_HOST_ADDRESS = "EventBusSettings:HostAddress";
    }
}

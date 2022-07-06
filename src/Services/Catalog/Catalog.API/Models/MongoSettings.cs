namespace Catalog.API.Models
{
    
    public class MongoSettings
    {
        public const string SectionName = "DatabaseSettings";
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CollectionName { get;set; } = null!;
    }
}

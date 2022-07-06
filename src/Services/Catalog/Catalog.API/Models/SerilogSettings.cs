namespace Catalog.API.Models
{
    public class SerilogSettings
    {
        public const string SectionName = "Serilog";

        [ConfigurationKeyName("MinimumLevel")]
        public MinimumLevel MinLevel { get; set; } = null!;
        public ElasticSearchSettings ElasticSearch { get; set; } = null!;

        public class ElasticSearchSettings
        {
            public string Uri { get; set; } = null!;
        }

        public class MinimumLevel
        {
            public string Default { get; set; } = null!;
        }
    }
}

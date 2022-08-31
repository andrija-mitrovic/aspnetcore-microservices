namespace Shopping.Aggregator.Web.Models
{
    public class ApiSettings
    {
        public static Catalog Catalog { get; set; } = null!;
        public static Basket Basket { get; set; } = null!;
        public static Ordering Ordering { get; set; } = null!;
    }
}

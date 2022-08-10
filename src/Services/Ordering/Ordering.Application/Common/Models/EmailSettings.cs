namespace Ordering.Application.Common.Models
{
    public class EmailSettings
    {
        public const string SectionName = "EmailSettings";
        public string ApiKey { get; set; } = null!;
        public string FromAddress { get; set; } = null!;
        public string FromName { get; set; } = null!;
    }
}

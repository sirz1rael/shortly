namespace url_shortener.Models
{
    public class Click
    {
        public int Id { get; set; }
        public int UrlId { get; set; }
        public Url Url { get; set; } = null!;

        // Geodata
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }

        // Browser & device
        public string? Browser { get; set; }
        public string? BrowserVersion { get; set; }
        public string? Platform { get; set; }
        public string? DeviceType { get; set; }

        public string? Refferer { get; set; }
        public string? ReferrerDomain { get; set; }

        // User-agent
        public string? IPAddress { get; set; }
        public string? UserAgent { get; set; }

        // Timestampts
        public DateTime ClickedAt { get; set; } = DateTime.UtcNow;

        // Session
        public string? SessionId { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace url_shortener.Models
{
    public enum UrlStatus
    {
        Active = 0,
        Inactive = 1,
        Expired = 2,
        Blocked = 3,
        Limited = 4
    }

    [Index(nameof(ShortCode))]
    [Index(nameof(CreatedAt))]
    [Index(nameof(ExpiresAt))]
    [Index(nameof(IsActive))]
    public class Url
    {
        public int Id { get; set; }
        public required string OriginalUrl { get; set; }
        public required string ShortCode { get; set; }
        public int CreatorId { get; set; }
        public User Creator { get; set; } = null!;
        public int ClickCount { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? ExpiresAt { get; set; }
        public bool IsActive { get; set; } = true;
        public string? PasswordHash { get; set; }
        public int? MaxClicks { get; set; }

        public UrlStatus Status { get; set; } = UrlStatus.Active;
        public string? Tags { get; set; }
        public string? Title { get; set; }
        public string? MostCommonCountry { get; set; }
        public int? MostCommonCountryCount { get; set; }

        public string? MostCommonReferrer { get; set; }
        public int? MostCommonReferrerCount { get; set; }

        public DateTime? FirstClickAt { get; set; }
        public DateTime? LastClickAt { get; set; }

        public string? PeakActivityHour { get; set; }
        [JsonIgnore]
        public ICollection<Click> Clicks { get; set; } = new List<Click>();

    }
}

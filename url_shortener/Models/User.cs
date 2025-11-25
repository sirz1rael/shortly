using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace url_shortener.Models
{
    [Index(nameof(PublicId), nameof(Email))]
    public class User
    {
        public required int Id { get; set; }

        [MaxLength(64)]
        public required string PublicId { get; set; }

        [EmailAddress]
        [MaxLength(255)]
        public required string Email { get; set; }
        public bool EmailConfirmed { get; set; } = false;
        public string? EmailConfirmationToken { get; set; }

        [JsonIgnore]
        public required string PasswordHash { get; set; }

        [JsonIgnore]
        public string? PasswordResetToken { get; set; }

        [JsonIgnore]
        public DateTime? PasswordResetTokenExpires { get; set; }
        [MaxLength(127)]
        public required string Username { get; set; }
        [JsonIgnore]
        public ICollection<Url> CreatedUrls { get; set; } = null!;
        public int UrlCount { get; set; } = 0;
        public int MaxUrlsPerDay { get; set; } = 3; // TODO(): Remove it from here and place it into Permissions of user role
        public bool IsPermanentlyBlocked { get; set; } = false;
        public DateTime? BlockedUntil { get; set; }
        public string? BlockReason { get; set; }

        [NotMapped]
        public bool IsTemporarilyBlocked => BlockedUntil.HasValue && BlockedUntil > DateTime.UtcNow;

        [NotMapped]
        public bool IsAnyBlocked => IsPermanentlyBlocked || IsTemporarilyBlocked;

        [NotMapped]
        public bool CanCreateMoreUrls => UrlCount < MaxUrlsPerDay && !IsAnyBlocked;

        // Role mappings
        [NotMapped]
        public bool IsPremium => RoleId == 2 || RoleId == 3;

        public int RoleId { get; set; } = 0; // User By Default
        public Role Role { get; set; } = null!;

        // Common timestampts
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Security and Activity Tracking
        public DateTime LastLoginAt { get; set; } = DateTime.UtcNow;
        public DateTime LastActivityAt { get; set; } = DateTime.UtcNow;
        public string? RegistrationIp { get; set; }
        public string? LastLoginIp { get; set; }
        public int FailedLoginAttempts { get; set; } = 0;
    }
}

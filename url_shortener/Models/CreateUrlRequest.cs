// none

using System.ComponentModel.DataAnnotations;

namespace url_shortener.Models
{
    public class CreateUrlRequest
    {
        [Required]
        [Url]
        public string OriginalUrl { get; set; } = string.Empty;
        [StringLength(20, MinimumLength = 4)]
        public string? CustomShortCode { get; set; }
    }
}

// none

using url_shortener.Models;

namespace url_shortener.Services
{
    public interface IUrlService
    {
        Task<UrlCreationResult> CreateShortUrlAsync(string originalUrl, string? customCode = null);
        Task<Url?> GetByShortCodeAsync(string shortCode);
        Task IncrementClickCountAsync(int urlId);
    }
}

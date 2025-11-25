// none


using url_shortener.Database;
using url_shortener.Models;

namespace url_shortener.Services
{
    public class UrlService(IUrlRepository urlRepository, IShortCodeGenerator shortCodeGenerator) : IUrlService
    {
        private readonly IUrlRepository _urlRepository = urlRepository;
        private readonly IShortCodeGenerator _shortCodeGenerator = shortCodeGenerator;

        public async Task<UrlCreationResult> CreateShortUrlAsync(string originalUrl, string? customCode = null)
        {
            if (string.IsNullOrWhiteSpace(originalUrl))
                return UrlCreationResult.Failure("Original URL cannot be empty.");

            if (!Uri.IsWellFormedUriString(originalUrl, UriKind.Absolute))
                return UrlCreationResult.Failure("Invalid URL format.");

            string shortCode;
            if (!string.IsNullOrEmpty(customCode))
            {
                if (await _urlRepository.ShortCodeExistsAsync(customCode))
                    return UrlCreationResult.Failure("This custom code already exists.");

                shortCode = customCode;
            } else
            {
                shortCode = await _shortCodeGenerator.GenerateUniqueCodeAsync();
            }

            var url = new Url
            {
                OriginalUrl = originalUrl,
                ShortCode = shortCode,
                CreatedAt = DateTime.UtcNow
            };

            await _urlRepository.AddAsync(url);

            return UrlCreationResult.Success($"https://short.ly/{shortCode}");

        }
        public Task<Url?> GetByShortCodeAsync(string shortCode) => throw new NotImplementedException();
        public Task IncrementClickCountAsync(int urlId) => throw new NotImplementedException();
    }
}

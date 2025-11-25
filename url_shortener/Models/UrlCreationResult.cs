// none

namespace url_shortener.Models
{
    public class UrlCreationResult
    {
        public bool IsSuccess { get; set; }
        public string? ShortUrl { get; set; }
        public string? ErrorMessage { get; set; }

        public static UrlCreationResult Success(string shortUrl)
        => new() { IsSuccess = true, ShortUrl = shortUrl };

        public static UrlCreationResult Failure(string error)
            => new() { IsSuccess = false, ErrorMessage = error };
    }
}

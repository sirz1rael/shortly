using url_shortener.Models;

namespace url_shortener.Database
{
    public interface IUrlRepository : IRepository<Url>
    {
        // Main statistics
        Task<int> GetTotalUrlsCountAsync();
        Task<int> GetUserUrlsCountAsync(int userId);
        Task<int> GetTotalClicksCountAsync();
        Task<int> GetUserClicksCountAsync(int userId);

        // Temporarirly statistics
        Task<int> GetUrlsCreatedTodayAsync();
        Task<int> GetUserUrlsCreatedTodayAsync(int userId);
        Task<int> GetClicksTodayAsync();
        Task<int> GetUserClicksTodayAsync(int userId);

        // Statistics by periods
        Task<int> GetUrlsCreatedInPeriodAsync(DateTime start, DateTime end);
        Task<int> GetClicksInPeriodAsync(DateTime start, DateTime end);
        Task<Dictionary<DateTime, int>> GetDailyClicksAsync(int urlId, int days = 30);
        Task<Dictionary<DateTime, int>> GetDailyUrlsCreatedAsync(int days = 30);

        // Tops and raitings
        Task<IEnumerable<Url>> GetMostPopularUrlsAsync(int count = 10);
        Task<IEnumerable<Url>> GetUserMostPopularUrlsAsync(int userId, int count = 5);
        Task<IEnumerable<Url>> GetRecentUrlsAsync(int count = 20);
        Task<IEnumerable<Url>> GetUserRecentUrlsAsync(int userId, int count = 10);

        // Search and filters
        Task<Url> GetByShortCodeAsync(string shortCode);
        Task<bool> ShortCodeExistsAsync(string shortCode);
        Task<IEnumerable<Url>> GetExpiredUrlsAsync();
        Task<IEnumerable<Url>> GetUserUrlsAsync(int userId, int page = 1, int pageSize = 50);

        // Geo & analytics
        Task<Dictionary<string, int>> GetClicksByCountryAsync(int urlId);
        Task<Dictionary<string, int>> GetClicksByBrowserAsync(int urlId);
        Task<Dictionary<string, int>> GetClicksByReferrerAsync(int urlId);

        // Operational methods
        Task IncrementClickCountAsync(int urlId);
        Task<bool> CleanupExpiredUrlsAsync();
        Task<int> GetActiveUrlsCountAsync();


    }
}

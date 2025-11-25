using url_shortener.Models;

namespace url_shortener.Database
{
    public class UrlRepository(AppDbContext context) : Repository<Url>(context), IUrlRepository
    {
        public Task<bool> CleanupExpiredUrlsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetActiveUrlsCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Url> GetByShortCodeAsync(string shortCode)
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<string, int>> GetClicksByBrowserAsync(int urlId)
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<string, int>> GetClicksByCountryAsync(int urlId)
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<string, int>> GetClicksByReferrerAsync(int urlId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetClicksInPeriodAsync(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetClicksTodayAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<DateTime, int>> GetDailyClicksAsync(int urlId, int days = 30)
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<DateTime, int>> GetDailyUrlsCreatedAsync(int days = 30)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Url>> GetExpiredUrlsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Url>> GetMostPopularUrlsAsync(int count = 10)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Url>> GetRecentUrlsAsync(int count = 20)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalClicksCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalUrlsCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetUrlsCreatedInPeriodAsync(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetUrlsCreatedTodayAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetUserClicksCountAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetUserClicksTodayAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Url>> GetUserMostPopularUrlsAsync(int userId, int count = 5)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Url>> GetUserRecentUrlsAsync(int userId, int count = 10)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Url>> GetUserUrlsAsync(int userId, int page = 1, int pageSize = 50)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetUserUrlsCountAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetUserUrlsCreatedTodayAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task IncrementClickCountAsync(int urlId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ShortCodeExistsAsync(string shortCode)
        {
            throw new NotImplementedException();
        }
    }
}

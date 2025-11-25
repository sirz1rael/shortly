using url_shortener.Models;

namespace url_shortener.Database
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByPublicId(string public_id);
        // ...
    }
}

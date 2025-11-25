using Microsoft.EntityFrameworkCore;
using url_shortener.Models;

namespace url_shortener.Database
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }
        public async Task<User?> GetByPublicId(string public_id)
        {
            return await _context.Users.FindAsync(public_id);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using UserManagement.Contexts;
using UserManagement.Models;

namespace UserManagement.Repositories
{
    public class UserRepository : Repository<string, User>
    {
        public UserRepository(UserAuthContext context)
        {
            _context = context;
        }

        public async override Task<User> Get(string key)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == key);
            if (user == null)
            {
                throw new Exception("Entity not found");
            }
            return user;
        }

        public async override Task<ICollection<User>> GetAll()
        {
            if (_context.Users.Count() == 0)
            {
                throw new Exception("No entities found");
            }
            return await _context.Users.ToListAsync();

        }
    }
}

using Microsoft.EntityFrameworkCore;
using RSSManagmentService.Entities;

namespace RSSManagmentService.DataAccess.Repository
{
    public class UserRepository
    {
        private readonly SqlContext _context;

        public UserRepository(SqlContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsExistAsync(string login)
        {
            return await _context.Users.AnyAsync(u => u.Login == login);
        }

        public async Task<User> GetAsync(User user)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Login == user.Login && u.Password == user.Password);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FirstAsync(x => x.Id == id);
        }
    }
}
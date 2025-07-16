
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace Server.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterAsync(RegisterModel model)
        {
            if (await _context.UserTable.AnyAsync(u => u.Email == model.Email))
                return false; // User already exists
            var user = new UserTable
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password
            };

            _context.UserTable.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> LoginAsync(LoginModel model)
        {
            var user = await _context.UserTable.SingleOrDefaultAsync(u => u.Email == model.Email);
            if (user == null)
            {
                return false;
            }
            return user.Password == model.Password;
        }
    }
}


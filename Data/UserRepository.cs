using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SEM.API.Interfaces;
using SEM.API.Models;
using SEM.API.Data;

namespace SEM.API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.Include(u => u.Department)
                                       .Include(u => u.Schedules)
                                       .SingleOrDefaultAsync(u => u.UserEmail == email);
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.Include(u => u.Department)
                                       .Include(u => u.Schedules)
                                       .SingleOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.Include(u => u.Department)
                                       .Include(u => u.Schedules)
                                       .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}
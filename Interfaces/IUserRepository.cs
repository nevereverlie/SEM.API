using System.Collections.Generic;
using System.Threading.Tasks;
using Revisory_Control.API.Models;

namespace Revisory_Control.API.Interfaces
{
    public interface IUserRepository
    {
         void Update(User user);

         Task<bool> SaveAllAsync();
         Task<IEnumerable<User>> GetUsers();
         Task<User> GetUserById(int id);
         Task<User> GetUserByEmail(string email);
    }
}
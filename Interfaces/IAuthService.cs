using System.Threading.Tasks;
using Revisory_Control.API.DTOs;

namespace Revisory_Control.API.Interfaces
{
    public interface IAuthService
    {
         Task<UserDto> Login(LoginDto loginDto);
         Task<UserDto> Register(RegisterDto registerDto);
         Task<bool> UserExists(string email);
    }
}
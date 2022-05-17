using System.Threading.Tasks;
using SEM.API.DTOs;

namespace SEM.API.Interfaces
{
    public interface IAuthService
    {
         Task<UserDto> Login(LoginDto loginDto);
         Task<UserDto> Register(RegisterDto registerDto);
         Task<bool> UserExists(string email);
    }
}
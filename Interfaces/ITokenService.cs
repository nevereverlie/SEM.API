using SEM.API.Models;

namespace SEM.API.Interfaces
{
    public interface ITokenService
    {
         string CreateToken(User user);
    }
}
using Revisory_Control.API.Models;

namespace Revisory_Control.API.Interfaces
{
    public interface ITokenService
    {
         string CreateToken(User user);
    }
}
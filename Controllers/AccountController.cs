using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SEM.API.DTOs;
using SEM.API.Interfaces;
using SEM.API.Models;
using SEM.API.Data;

namespace SEM.API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IAppRepository _appRepository;
        private readonly IAuthService _authService;

        public AccountController(IUserRepository userRepository,
                                 ITokenService tokenService,
                                 IAppRepository appRepository,
                                 IAuthService authService)
        {
            _tokenService = tokenService;
            _appRepository = appRepository;
            _authService = authService;
            _userRepository = userRepository;
        }


        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Email)) return BadRequest("Email is taken");

            return await _authService.Register(registerDto);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userRepository.GetUserByEmail(loginDto.Email);

            if (user == null) return Unauthorized("Invalid email");

            var userToLogin = await _authService.Login(loginDto);

            if (userToLogin == null) return Unauthorized("Invalid password");

            return userToLogin;
        }

        private async Task<bool> UserExists(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);

            return user == null ? false : true;
        }
    }

}
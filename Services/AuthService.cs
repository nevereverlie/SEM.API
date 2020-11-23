using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Revisory_Control.API.DTOs;
using Revisory_Control.API.Interfaces;
using Revisory_Control.API.Models;

namespace Revisory_Control.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAppRepository _appRepository;
        private readonly ITokenService _tokenService;

        public AuthService(IUserRepository userRepository,
                           IAppRepository appRepository,
                           ITokenService tokenService)
        {
            _userRepository = userRepository;
            _appRepository = appRepository;
            _tokenService = tokenService;
        }
        public async Task<UserDto> Login(LoginDto loginDto)
        {
            var user = await _userRepository.GetUserByEmail(loginDto.Email);

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return null;
            }
            
            return new UserDto
            {
                UserId = user.UserId,
                Email = user.UserEmail,
                Token = _tokenService.CreateToken(user)
            };

        }

        public async Task<UserDto> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Email)) return null;

            using var hmac = new HMACSHA512();

            var user = new User
            {
                Lastname = registerDto.Lastname.ToLower(),
                Firstname = registerDto.Firstname.ToLower(),
                UserEmail = registerDto.Email,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            _appRepository.Add(user);

            await _appRepository.SaveAll();

            return new UserDto
            {
                Email = user.UserEmail,
                Token = _tokenService.CreateToken(user)
            };

        }

        public async Task<bool> UserExists(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);

            return user == null ? false : true;
        }
    }
}
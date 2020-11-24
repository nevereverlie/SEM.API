using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Revisory_Control.API.DTOs;
using Revisory_Control.API.Interfaces;
using Revisory_Control.API.Models;
using RevisoryControl.API.Data;

namespace Revisory_Control.API.Controllers
{
    
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IFaceDetectionService _faceDetection;
        private readonly IAppRepository _appRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public UsersController(IUserRepository userRepository,
                               IMapper mapper,
                               IFaceDetectionService faceDetection,
                               IAppRepository appRepository,
                               IDepartmentRepository departmentRepository)
        {
            _mapper = mapper;
            _faceDetection = faceDetection;
            _appRepository = appRepository;
            _departmentRepository = departmentRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetUsers()
        {
            var users = await _userRepository.GetUsers();

            var usersToReturn = _mapper.Map<IEnumerable<EmployeeDto>>(users);

            return Ok(usersToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);

            return _mapper.Map<EmployeeDto>(user);
        }

        [HttpGet("byEmail/{email}")]
        public async Task<ActionResult<EmployeeDto>> GetUserByEmail(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);

            return _mapper.Map<EmployeeDto>(user);
        }

        [HttpPost("{id}/face")]
        public bool IsUserFaceDetected(IFormFile faceImage, int id)
        {
            Image face = Image.FromStream(faceImage.OpenReadStream(), true, true);

            return _faceDetection.IsFaceDetected(face, id);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser(UserForUpdateDto user)
        {
            var userToUpdate = await _userRepository.GetUserById(user.UserId);

            if (userToUpdate == null) return BadRequest("No such user in database");

            using var hmac = new HMACSHA512();

            userToUpdate.Lastname = user.Lastname;
            userToUpdate.Firstname = user.Firstname;
            userToUpdate.UserEmail = user.UserEmail;
            //userToUpdate.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.UserPassword));
            //userToUpdate.PasswordSalt = hmac.Key;

            Department depForUpdate = await _departmentRepository.GetDepartmentByName(user.Department);
            if (depForUpdate != null)
                userToUpdate.Department = depForUpdate;

            _appRepository.Update(userToUpdate);

            if (await _appRepository.SaveAll()) return Ok(userToUpdate);

            return BadRequest("Problem updating this user");
        }
        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var userToDelete = await _userRepository.GetUserById(id);

            if (userToDelete == null) return BadRequest("No such user in database");

            _appRepository.Delete(userToDelete);

            if (await _appRepository.SaveAll()) return Ok("User №" + id + " successfully deleted");

            return BadRequest("Problem deleting this user");
        }
    }
}
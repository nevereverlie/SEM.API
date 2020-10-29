using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

        public UsersController(IUserRepository userRepository,
                               IMapper mapper,
                               IFaceDetectionService faceDetection,
                               IAppRepository appRepository)
        {
            _mapper = mapper;
            _faceDetection = faceDetection;
            _appRepository = appRepository;
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

        // [HttpPut("update")]
        // public async Task<IActionResult> UpdateUser(User user)
        // {
        //     var userToUpdate = new User
        //     {

        //     }
        // }
    }
}
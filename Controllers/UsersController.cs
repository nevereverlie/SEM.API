using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Revisory_Control.API.DTOs;
using Revisory_Control.API.Interfaces;
using Revisory_Control.API.Models;
using RevisoryControl.API.Data;

namespace Revisory_Control.API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
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
    }
}
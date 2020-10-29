using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Revisory_Control.API.DTOs;
using Revisory_Control.API.Interfaces;
using Revisory_Control.API.Models;

namespace Revisory_Control.API.Controllers
{
    public class DepartmentsController : BaseApiController
    {
        private readonly IDepartmentRepository _departmentRepo;
        private readonly IAppRepository _appRepository;
        private readonly IMapper _mapper;

        public DepartmentsController(IDepartmentRepository departmentRepository,
                                     IAppRepository appRepository,
                                     IMapper mapper)
        {
            _mapper = mapper;
            _departmentRepo = departmentRepository;
            _appRepository = appRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<DepartmentDto>> GetDepartments()
        {
            var deps = await _departmentRepo.GetDepartments();

            var depsToReturn = _mapper.Map<IEnumerable<DepartmentDto>>(deps);

            return depsToReturn;
        }
        [HttpGet("{id:int}")]
        public async Task<DepartmentDto> GetDepartmentById(int id)
        {
            var dep = await _departmentRepo.GetDepartmentById(id);

            var depToReturn = _mapper.Map<DepartmentDto>(dep);

            return depToReturn;
        }
        [HttpGet("byName/{depName}")]
        public async Task<DepartmentDto> GetDepartmentByName(string depName)
        {
            var dep = await _departmentRepo.GetDepartmentByName(depName);

            var depToReturn = _mapper.Map<DepartmentDto>(dep);

            return depToReturn;
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateDepartment(DepartmentDto department)
        {
            var depToUpdate = await _departmentRepo.GetDepartmentById(department.DepartmentId);

            if (depToUpdate == null) return BadRequest("No such department in the database");

            depToUpdate.DepartmentName = department.DepartmentName;

            _appRepository.Update(depToUpdate);

            if (await _appRepository.SaveAll()) return Ok(depToUpdate);

            return BadRequest("Problem updating this department");
        }
        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var depToDelete = await _departmentRepo.GetDepartmentById(id);
                        
            if (depToDelete == null) return BadRequest("No such department in the database");

            _appRepository.Delete(depToDelete);

            if (await _appRepository.SaveAll()) return Ok("Successfully deleted department №" + id);

            return BadRequest("Problem deleting this department");
        }
    }
}
using AutoMapper;
using Revisory_Control.API.DTOs;
using Revisory_Control.API.Models;

namespace Revisory_Control.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, EmployeeDto>();
            CreateMap<Schedule, ScheduleDto>();
            CreateMap<Department, DepartmentDto>();
        }
    }
}
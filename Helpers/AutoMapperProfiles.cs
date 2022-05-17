using AutoMapper;
using SEM.API.DTOs;
using SEM.API.Models;

namespace SEM.API.Helpers
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
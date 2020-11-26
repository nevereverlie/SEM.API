using System.Collections.Generic;
using Revisory_Control.API.Models;

namespace Revisory_Control.API.DTOs
{
    public class EmployeeDto
    {
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }     
        public DepartmentDto Department { get; set; }
        public int WorkedHours { get; set; }
        public int WastedHours { get; set; }
        public int WorkedMinutes { get; set; }
        public int WastedMinutes { get; set; }
        public ICollection<ScheduleDto> Schedules { get; set; }
    
    }
}
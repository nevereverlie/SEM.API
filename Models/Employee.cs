using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Revisory_Control.API.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeEmail { get; set; }

        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }     
        public Department Department { get; set; }
        public int WorkedHours { get; set; }
        public int WastedHours { get; set; }
        public ICollection<Schedule> Schedules { get; set; }

    }
}
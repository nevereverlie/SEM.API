using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Revisory_Control.API.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserEmail { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }     
        public Department Department { get; set; }
        public int WorkedHours { get; set; }
        public int WastedHours { get; set; }
        public ICollection<Schedule> Schedules { get; set; }

    }
}
using System.Collections.Generic;

namespace SEM.API.Models
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
        public int WorkedMinutes { get; set; }
        public int WastedMinutes { get; set; }
        public string[] AllowedApps { get; set; }

        public void MinutesToHours(bool isWorked)
        {
            switch (isWorked)
            {
                case false:
                    WastedMinutes++;
                    if (WastedMinutes >= 60)
                    {
                        WastedMinutes = 0;
                        WastedHours++;
                    }
                    break;
                case true:
                    WorkedMinutes++;
                    if (WorkedMinutes >= 60)
                    {
                        WorkedMinutes = 0;
                        WorkedHours++;
                    }
                    break;
            }
        }
    }
}
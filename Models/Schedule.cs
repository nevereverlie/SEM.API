using System;

namespace SEM.API.Models
{
    public class Schedule
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int WeekDayId { get; set; }
        public WeekDay WeekDay { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
    }
}
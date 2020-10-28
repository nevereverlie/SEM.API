using System;

namespace Revisory_Control.API.Models
{
    public class Schedule
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int WeekDayId { get; set; }
        public WeekDay WeekDay { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
    }
}
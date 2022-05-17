using System.Collections.Generic;

namespace SEM.API.Models
{
    public class WeekDay
    {
        public int WeekDayId { get; set; }
        public string WeekDayName { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}
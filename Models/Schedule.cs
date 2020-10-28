using System;

namespace Revisory_Control.API.Models
{
    public class Schedule
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int WeekDayId { get; set; }
        public WeekDay WeekDay { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
    }
}
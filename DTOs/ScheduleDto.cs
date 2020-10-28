using System;

namespace Revisory_Control.API.DTOs
{
    public class ScheduleDto
    {
        public int WeekDayId { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }

    }
}
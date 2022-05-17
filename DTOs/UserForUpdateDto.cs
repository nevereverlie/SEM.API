namespace SEM.API.DTOs
{
    public class UserForUpdateDto
    {
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Department { get; set; } 
        public int WorkedHours { get; set; }
        public int WastedHours { get; set; }
        public int WorkedMinutes { get; set; }
        public int WastedMinutes { get; set; }
        public string AllowedApps { get; set; } //JSON string
    }
}
namespace Revisory_Control.API.DTOs
{
    public class UserForUpdateDto
    {
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Department { get; set; }
        public int WorkedHours { get; set; }
        public int WastedHours { get; set; }
    }
}
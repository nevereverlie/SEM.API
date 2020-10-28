using System.ComponentModel.DataAnnotations;

namespace Revisory_Control.API.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
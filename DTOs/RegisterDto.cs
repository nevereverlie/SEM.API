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
        [StringLength(30, MinimumLength = 4, ErrorMessage = "You must specify password between 4 and 30 characters!")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
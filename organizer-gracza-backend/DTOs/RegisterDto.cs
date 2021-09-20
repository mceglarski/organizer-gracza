using System.ComponentModel.DataAnnotations;

namespace organizer_gracza_backend.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        [Required]
        [StringLength(24, MinimumLength = 8)]
        public string Password { get; set; }
    }
}
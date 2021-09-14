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
        public string Password { get; set; }
    }
}
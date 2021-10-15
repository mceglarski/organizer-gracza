using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.DTOs
{
    public class TeamUsersDto
    {
        public int TeamUserId { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public int TeamId { get; set; }
        public TeamDto Team { get; set; }
    }
}
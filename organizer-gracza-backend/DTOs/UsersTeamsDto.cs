namespace organizer_gracza_backend.DTOs
{
    public class UsersTeamsDto
    {
        public int TeamUserId { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public int TeamId { get; set; }
        public UsersInTeamsDto Team { get; set; }
    }
}
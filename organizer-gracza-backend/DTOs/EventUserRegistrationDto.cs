namespace organizer_gracza_backend.DTOs
{
    public class EventUserRegistrationDto
    {
        public int EventUserRegistrationId { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public int EventUserId { get; set; }
        public int EventResultId { get; set; }
    }
}
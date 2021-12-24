namespace organizer_gracza_backend.DTOs
{
    public class EventUserResultDto
    {
        public int EventUserResultId { get; set; }

        public int? UserId { get; set; }
        public UserDto User { get; set; }
        
        public int? EventUserId { get; set; }
        public EventUserDto EventUser { get; set; }
    }
}
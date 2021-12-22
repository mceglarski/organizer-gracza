namespace organizer_gracza_backend.DTOs
{
    public class EventResultDto
    {
        public int EventResultId { get; set; }
        public string WinnerName { get; set; }
        public int EventTeamRegistrationId { get; set; }
        public int EventUserRegistrationId { get; set; }
    }
}
namespace organizer_gracza_backend.DTOs
{
    public class EventTeamResultDto
    {
        public int EventTeamResultId { get; set; }
        public int TeamId { get; set; }
        public TeamDto Team { get; set; }
        
        public int EventTeamId { get; set; }
        public EventTeamDto EventTeam { get; set; }
    }
}
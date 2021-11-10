namespace organizer_gracza_backend.DTOs
{
    public class GeneralStatisticsDto
    {
        public int GeneralStatisticsId { get; set; }
        public int? EventsParticipated { get; set; }
        public int? EventsWon { get; set; }
        public int? PostWritten { get; set; }

        public int? UserId { get; set; }
        public UserDto User { get; set; }
    }
}
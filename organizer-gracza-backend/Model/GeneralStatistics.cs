using System.ComponentModel.DataAnnotations;

namespace organizer_gracza_backend.Model
{
    public class GeneralStatistics
    {
        [Key]
        public int IdGeneralStatistics { get; set; }
        public int EventsParticipated { get; set; }
        public int EventsWon { get; set; }
        public int PostWritten { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace organizer_gracza_backend.Model
{
    public class Profile
    {
        [Key]
        public int IdProfile { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public ICollection<Achievements> Achievements { get; set; }
        public ICollection<GameStatistics> GameStatistics { get; set; }
        public ICollection<GeneralStatistics> GeneralStatistics { get; set; }
    }
}
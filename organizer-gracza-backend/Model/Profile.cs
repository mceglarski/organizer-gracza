using System.Collections.Generic;
using System.Reflection.Metadata;

namespace organizer_gracza_backend.Model
{
    public class Profile
    {
        public User IdUser { get; set; }
        public string Description { get; set; }
        public Blob Avatar { get; set; }
        public ICollection<Achievements> Achievements { get; set; }
        public ICollection<GameStatistics> GameStatistics { get; set; }
        public ICollection<GeneralStatistics> GeneralStatistics { get; set; }
    }
}
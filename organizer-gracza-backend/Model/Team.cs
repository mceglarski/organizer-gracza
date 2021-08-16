using System.Collections.Generic;

namespace organizer_gracza_backend.Model
{
    public class Team
    {
        public int IdTeam { get; set; }
        public string Name { get; set; }
        public ICollection<TeamUser> TeamUser { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace organizer_gracza_backend.Model
{

    public class TeamUser
    {
        [Key]
        public int IdTeamUser { get; set; }
        public int IdUser { get; set; }
        public User User { get; set; }
        public int IdTeam { get; set; }
        public Team Team { get; set; }
    }
}
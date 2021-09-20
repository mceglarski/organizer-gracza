using System.ComponentModel.DataAnnotations;

namespace organizer_gracza_backend.Model
{

    public class TeamUser
    {
        [Key]
        public int TeamUserId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
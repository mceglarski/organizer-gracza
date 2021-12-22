using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace organizer_gracza_backend.Model
{
    public class EventUserResult
    {
        [Key]
        public int EventUserResultId { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }
        
        public int? EventUserId { get; set; }
        public EventUser EventUser { get; set; }
        
    }
}
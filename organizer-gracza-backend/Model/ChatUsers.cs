using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace organizer_gracza_backend.Model
{
    public class ChatUsers
    {
        [Key]
        public int ChatUsersId { get; set; }
        public ICollection<User> User { get; set; }
        public Chat Chat { get; set; }
    }
}
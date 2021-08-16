using System.Collections.Generic;

namespace organizer_gracza_backend.Model
{
    public class ChatUsers
    {
        public int IdChatUsers { get; set; }
        public ICollection<User> User { get; set; }
        public Chat Chat { get; set; }
    }
}
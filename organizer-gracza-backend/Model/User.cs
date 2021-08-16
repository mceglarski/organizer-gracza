using System.Collections.Generic;

namespace organizer_gracza_backend.Model
{
    public class User
    {
        public int IdUser { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public ICollection<TeamUser> TeamUser{ get; set; }
    }
}
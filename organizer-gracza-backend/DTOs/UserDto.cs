using System.Collections.Generic;

namespace organizer_gracza_backend.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Nickname { get; set; }
        public string Token { get; set; }

        public string PhotoUrl { get; set; }
        
        public string Description { get; set; }
        
        public ICollection<UserGameDto> UserGames { get; set; }


    }
}
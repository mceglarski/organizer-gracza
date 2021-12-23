using System;
using System.Collections.Generic;

namespace organizer_gracza_backend.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }

        public DateTime LastActive { get; set; }

        public string Description { get; set; }
        public string SteamId { get; set; }

        public string PhotoUrl { get; set; }
        public ICollection<PhotoDto> Photos { get; set; }
        public ICollection<UserGameDto> UserGames { get; set; }

    }
}
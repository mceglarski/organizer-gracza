using System.Collections;
using System.Collections.Generic;

namespace organizer_gracza_backend.DTOs
{
    public class MemberUpdateDto
    {
        public string Nickname { get; set; }
        public string Description { get; set; }
        public ICollection<UserGameDto> UserGames { get; set; }
    }
}
using System.Collections;
using System.Collections.Generic;

namespace organizer_gracza_backend.DTOs
{
    public class MemberUpdateDto
    {
        public string Nickname { get; set; }
        public string Description { get; set; }
        public string SteamId { get; set; }
        public bool EmailConfirmed { get; set; }
        public string NewPassword { get; set; }
    }
}
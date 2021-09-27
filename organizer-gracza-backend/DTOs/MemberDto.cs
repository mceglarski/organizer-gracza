using System;
using System.Collections.Generic;
using organizer_gracza_backend.Model;

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

        public string PhotoUrl { get; set; }
        public ICollection<PhotoDto> Photos { get; set; }
    }
}
using System.Collections.Generic;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.DTOs
{
    public class TeamDto
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<TeamUsersDto> TeamUser { get; set; }

    }
}
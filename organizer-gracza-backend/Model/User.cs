using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace organizer_gracza_backend.Model
{
    public class User : IdentityUser<int>
    {
        public string Nickname { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;

        public ICollection<EventUserRegistration> EventUserRegistration { get; set; }
        public ICollection<TeamUser> TeamUser{ get; set; }
        public ICollection<Photo> Photos { get; set; }

        public ICollection<Message> MessagesSent { get; set; }
        public ICollection<Message> MessagesReceived { get; set; }
        
        public ICollection<UserRole> UserRoles { get; set; }

        public ICollection<GameStatistics> GameStatistics { get; set; }
        public GeneralStatistics GeneralStatistics { get; set; }
        
        public ICollection<Achievements> Achievements { get; set; }
        public UserAchievementCounter UserAchievementCounter { get; set; }
        
    }
}
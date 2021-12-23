using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace organizer_gracza_backend.Model
{
    public class User : IdentityUser<int>
    {
        public string Nickname { get; set; }
        
        public string Description { get; set; }

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
        
        public ICollection<UserAchievement> UserAchievements { get; set; }
        public UserAchievementCounter UserAchievementCounter { get; set; }
        
        public ICollection<Reminder> Reminders { get; set; }
        
        public ICollection<Articles> Articles { get; set; }
        
        public ICollection<ForumThread> ForumThreads { get; set; }
        public ICollection<ForumPost> ForumPosts { get; set; }

        public ICollection<UserGame> UserGames { get; set; }
        public ICollection<EventUserResult> EventUserResult { get; set; }
    }
}
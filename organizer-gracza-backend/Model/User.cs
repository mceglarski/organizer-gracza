using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace organizer_gracza_backend.Model
{
    public class User : IdentityUser<int>
    {
        [MinLength(2), MaxLength(20)] public override string UserName { get; set; }
        [MinLength(2), MaxLength(20)] public string Nickname { get; set; }
        [MaxLength(1000)] public string Description { get; set; }
        [MinLength(17), MaxLength(17)] public string SteamId { get; set; }
        [MaxLength(50)] public override string Email { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;

        public ICollection<EventUserRegistration> EventUserRegistration { get; set; }
        public ICollection<TeamUser> TeamUser { get; set; }
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
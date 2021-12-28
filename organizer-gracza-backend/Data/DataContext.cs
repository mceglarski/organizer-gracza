using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using organizer_gracza_backend.DTOs;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Data
{
    public class DataContext : IdentityDbContext<User, AppRole, int, IdentityUserClaim<int>, 
        UserRole, IdentityUserLogin<int>,IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }
        
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamUser> TeamUsers { get; set; }
        public DbSet<EventTeam> EventTeam { get; set; }
        public DbSet<EventUser> EventUser { get; set; }
        public DbSet<EventTeamRegistration> EventTeamRegistration { get; set; }
        public DbSet<EventUserRegistration> EventUserRegistration { get; set; }
        public DbSet<EventTeamResult> EventTeamResult { get; set; }
        public DbSet<EventUserResult> EventUserResult { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Achievements> Achievements { get; set; }
        public DbSet<GeneralStatistics> GeneralStatistics { get; set; }
        public DbSet<GameStatistics> GameStatistics { get; set; }
        public DbSet<ForumThread> ForumThread { get; set; }
        public DbSet<ForumPost> ForumPost { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Articles> Articles { get; set; }
        public DbSet<Reminder> Reminder { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<UserAchievementCounter> UserAchievementCounters { get; set; }
        public DbSet<UserGame> UserGame { get; set; }
        public DbSet<UserAchievement> UserAchievements { get; set; }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<User>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
            
            modelBuilder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            modelBuilder.Entity<TeamUser>()
                .HasOne(x => x.Team)
                .WithMany(x => x.TeamUser)
                .HasForeignKey(x => x.TeamId);

            modelBuilder.Entity<TeamUser>()
                .HasOne(x => x.User)
                .WithMany(x => x.TeamUser)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<Message>()
                .HasOne(u => u.Recipient)
                .WithMany(m => m.MessagesReceived)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Message>()
                .HasOne(u => u.Sender)
                .WithMany(m => m.MessagesSent)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EventTeamResult>()
                .HasOne(s => s.EventTeam)
                .WithOne(ad => ad.EventTeamResult)
                .HasForeignKey<EventTeam>(ad => ad.EventTeamResultId);

            modelBuilder.Entity<EventUserResult>()
                .HasOne(s => s.EventUser)
                .WithOne(ad => ad.EventUserResult)
                .HasForeignKey<EventUser>(ad => ad.EventUserResultId);
        }
    }
}
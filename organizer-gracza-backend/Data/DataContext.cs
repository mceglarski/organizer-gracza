using Microsoft.EntityFrameworkCore;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamUser> TeamUsers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventRegistration> EventRegistrations { get; set; }
        public DbSet<EventResult> EventResults { get; set; }
        public DbSet<Stream> Streams { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Achievements> Achievements { get; set; }
        public DbSet<GeneralStatistics> GeneralStatistics { get; set; }
        public DbSet<GameStatistics> GameStatistics { get; set; }
        public DbSet<ForumThread> ForumThread { get; set; }
        public DbSet<ForumPost> ForumPost { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ChatUsers> ChatUsers { get; set; }
        public DbSet<Articles> Articles { get; set; }
        public DbSet<Reminder> Reminder { get; set; }
        public DbSet<Profile> Profile { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
        }
    }
}
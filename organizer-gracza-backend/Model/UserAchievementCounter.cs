namespace organizer_gracza_backend.Model
{
    public class UserAchievementCounter
    {
        public int UserAchievementCounterId { get; set; }
        public int? NumberOfTeamsCreated { get; set; }
        public int? NumberOfTeamsJoined { get; set; }
        
        public int? NumberOfThreadsCreated { get; set; }
        public int? NumberOfPostsCreated { get; set; }
        public int? NumberOfEventUserJoined { get; set; }
        
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
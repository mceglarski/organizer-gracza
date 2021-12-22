namespace organizer_gracza_backend.DTOs
{
    public class UserAchievementCounterDto
    {
        public int UserAchievementCounterId { get; set; }
        public int? NumberOfTeamsCreated { get; set; }
        public int? NumberOfTeamsJoined { get; set; }
        public int? NumberOfThreadsCreated { get; set; }
        public int? NumberOfPostsCreated { get; set; }
        public int? NumberOfEventUserJoined { get; set; }
        public int? UserId { get; set; }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Interfaces
{
    public interface IForumPost
    {
        Task<ForumPost> GetForumPostAsync(int forumPostId);
        Task<IEnumerable<ForumPost>> GetForumPostsAsync();
        Task<IEnumerable<ForumPost>> GetForumPostByUserId(int userId);
        void AddForumPost(ForumPost forumPost);
        void DeleteForumPost(ForumPost forumPost);
        Task<bool> SaveAllAsync();
        void UpdateForumPost(ForumPost forumPost);

    }
}
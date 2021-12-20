using System.Collections.Generic;
using System.Threading.Tasks;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Interfaces
{
    public interface IForumThread
    {
        Task<ForumThread> GetForumThreadAsync(int forumThreadId);
        Task<IEnumerable<ForumThread>> GetForumThreadsAsync();
        Task<IEnumerable<ForumThread>> GetForumThreadsByUserId(int userId);
        void AddForumThread(ForumThread forumThread);
        void DeleteForumThread(ForumThread forumThread);
        Task<bool> SaveAllAsync();
        void UpdateForumThread(ForumThread forumThread);
    }
}
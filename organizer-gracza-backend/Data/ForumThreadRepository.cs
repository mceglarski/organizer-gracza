using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Data
{
    public class ForumThreadRepository : IForumThread
    {
        private readonly DataContext _context;
        public ForumThreadRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<ForumThread> GetForumThreadAsync(int forumThreadId)
        {
            return await _context.ForumThread
                .Include(u => u.User)
                .Include(g => g.Game)
                .Include(p => p.ForumPosts)
                .SingleOrDefaultAsync(x => x.ForumThreadId == forumThreadId);
        }
        
        public async Task<IEnumerable<ForumThread>> GetForumThreadsAsync()
        {
            return await _context.ForumThread
                .Include(u => u.User)
                .Include(g => g.Game)
                .Include(p => p.ForumPosts)
                .ToListAsync();
        }

        public async Task<IEnumerable<ForumThread>> GetForumThreadsByUserId(int userId)
        {
            return await _context.ForumThread
                .Include(u => u.User)
                .Include(g => g.Game)
                .Include(p => p.ForumPosts)
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public void AddForumThread(ForumThread forumThread)
        {
            _context.ForumThread.Add(forumThread);
        }

        public void DeleteForumThread(ForumThread forumThread)
        {
            _context.ForumThread.Remove(forumThread);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateForumThread(ForumThread forumThread)
        {
            _context.Attach(forumThread);
            _context.Entry(forumThread).State = EntityState.Modified;
        }
    }
}
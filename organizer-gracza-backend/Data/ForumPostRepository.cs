using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Data
{
    public class ForumPostRepository : IForumPost
    {
        private readonly DataContext _context;
        public ForumPostRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<ForumPost> GetForumPostAsync(int forumPostId)
        {
            return await _context.ForumPost
                .Include(u => u.User)
                .SingleOrDefaultAsync(x => x.ForumPostId == forumPostId);
        }

        public async Task<IEnumerable<ForumPost>> GetForumPostsAsync()
        {
            return await _context.ForumPost
                .Include(u => u.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<ForumPost>> GetForumPostByUserId(int userId)
        {
            return await _context.ForumPost
                .Include(u => u.User)
                .Where(x => x.UserId == userId)
                .ToListAsync();        
        }

        public void AddForumPost(ForumPost forumPost)
        {
            _context.ForumPost.Add(forumPost);
        }

        public void DeleteForumPost(ForumPost forumPost)
        {
            _context.ForumPost.Remove(forumPost);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateForumPost(ForumPost forumPost)
        {
            _context.Attach(forumPost);
            _context.Entry(forumPost).State = EntityState.Modified;
        }
    }
}
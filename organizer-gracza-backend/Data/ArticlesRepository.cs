using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Data
{
    public class ArticlesRepository : IArticlesRepository
    {
        private readonly DataContext _context;

        public ArticlesRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Articles> GetArticleById(int articleId)
        {
            return await _context.Articles
                .Include(u => u.User)
                .SingleOrDefaultAsync(x => x.ArticlesId == articleId);
        }

        public async Task<IEnumerable<Articles>> GetArticleByUserId(int userId)
        {
            return await _context.Articles
                .Include(u => u.User)
                .Where(u => u.UserId == userId)
                .ToListAsync();
        }

        public async Task<Articles> GetArticleForUser(int articleId, int userId)
        {
            return await _context.Articles
                .Include(u => u.User)
                .Where(u => u.UserId == userId)
                .SingleOrDefaultAsync(r => r.ArticlesId == articleId);
        }

        public async Task<IEnumerable<Articles>> GetArticles()
        {
            return await _context.Articles
                .Include(u => u.User)
                .ToListAsync();
        }

        public void AddArticle(Articles article)
        {
            _context.Articles.Add(article);
        }

        public void DeleteArticle(Articles article)
        {
            _context.Articles.Remove(article);
        }

        public void UpdateArticle(Articles article)
        {
            _context.Attach(article);
            _context.Entry(article).State = EntityState.Modified;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
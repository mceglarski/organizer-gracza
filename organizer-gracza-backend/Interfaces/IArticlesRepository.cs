using System.Collections.Generic;
using System.Threading.Tasks;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Interfaces
{
    public interface IArticlesRepository
    {
        Task<Articles> GetArticleById(int articleId);
        Task<IEnumerable<Articles>> GetArticleByUserId(int userId);
        Task<Articles> GetArticleForUser(int articleId, int userId);
        Task<IEnumerable<Articles>> GetArticles();
        void AddArticle(Articles article);
        void DeleteArticle(Articles article);
        void UpdateArticle(Articles article);
        Task<bool> SaveAllAsync();
    }
}
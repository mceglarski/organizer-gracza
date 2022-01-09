using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using organizer_gracza_backend.Data;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.UnitTests
{
    public class ArticlesTest
    {
        private DbContextOptions<DataContext> _dbContextOptions;

        [SetUp]
        public void Setup()
        {
            _dbContextOptions = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "testowabazadanych")
                .Options;
        }

        [Test]
        public void CheckIfGetArticleByIdMethodReturnsCorrectValue()
        {
            using (var context = new DataContext(_dbContextOptions))
            {
                context.Articles.Add(new Articles() { ArticlesId = 1, Title = "test", Content = "test", PublicationDate = new DateTime(2022,01,01), UserId = 1});
                context.SaveChanges();
            }

            using (var context = new DataContext(_dbContextOptions))
            {
                var articlesRepository = new ArticlesRepository(context);
                var articles = articlesRepository.GetArticleById(1);

                Assert.AreEqual(1, articles.Result.ArticlesId);
                context.Database.EnsureDeleted();
            }
        }
        
        [Test]
        public void CheckIfGetArticlesMethodReturnsCorrectValue()
        {
            using (var context = new DataContext(_dbContextOptions))
            {
                context.Articles.Add(new Articles() { ArticlesId = 1, Title = "test1", Content = "test1", PublicationDate = new DateTime(2022,02,01), UserId = 1});
                context.Articles.Add(new Articles() { ArticlesId = 2, Title = "test2", Content = "test2", PublicationDate = new DateTime(2022,02,01), UserId = 2});
                context.Articles.Add(new Articles() { ArticlesId = 3, Title = "test3", Content = "test3", PublicationDate = new DateTime(2022,02,01), UserId = 3});
                context.SaveChanges();
            }

            using (var context = new DataContext(_dbContextOptions))
            {
                var articlesRepository = new ArticlesRepository(context);
                var articles = articlesRepository.GetArticles();

                Assert.AreEqual(3, articles.Result.Count());
                context.Database.EnsureDeleted();
            }
        }
        
        [Test]
        public void CheckIfAddArticleMethodWorkingCorrectly()
        {
            var newArticle = new Articles()
            {
                ArticlesId = 1,
                Title = "test",
                Content = "test",
                PhotoUrl = "test",
                PublicationDate = new DateTime(2022,01,01),
                UserId = 1
            };

            using (var context = new DataContext(_dbContextOptions))
            {
                var articlesRepository = new ArticlesRepository(context);
                var articles = articlesRepository.GetArticles();

                Assert.AreEqual(0, articles.Result.Count());
            }

            using (var context = new DataContext(_dbContextOptions))
            {
                var articlesRepository = new ArticlesRepository(context);
                articlesRepository.AddArticle(newArticle);
                context.SaveChanges();
            }

            using (var context = new DataContext(_dbContextOptions))
            {
                var articlesRepository = new ArticlesRepository(context);
                var articles = articlesRepository.GetArticles();

                Assert.AreEqual(1, articles.Result.Count());
                context.Database.EnsureDeleted();
            }
        }
        
        [Test]
        public void CheckIfDeleteArticleMethodWorkingCorrectly()
        {
            using (var context = new DataContext(_dbContextOptions))
            {
                context.Articles.Add(new Articles() { ArticlesId = 1, Title = "test1", Content = "test1", PublicationDate = new DateTime(2022,02,01), UserId = 1});
                context.Articles.Add(new Articles() { ArticlesId = 2, Title = "test2", Content = "test2", PublicationDate = new DateTime(2022,02,01), UserId = 2});
                context.Articles.Add(new Articles() { ArticlesId = 3, Title = "test3", Content = "test3", PublicationDate = new DateTime(2022,02,01), UserId = 3});
                context.SaveChanges();
            }

            using (var context = new DataContext(_dbContextOptions))
            {
                var articlesRepository = new ArticlesRepository(context);
                var articles = articlesRepository.GetArticles();

                Assert.AreEqual(3, articles.Result.Count());
            }

            using (var context = new DataContext(_dbContextOptions))
            {
                var articlesRepository = new ArticlesRepository(context);
                foreach (var articleToDelete in context.Articles.Where(x => x.ArticlesId == 1))
                    articlesRepository.DeleteArticle(articleToDelete);
                context.SaveChanges();
                var article = articlesRepository.GetArticles();
                Assert.AreEqual(2, article.Result.Count());
                context.Database.EnsureDeleted();
            }
        }
        
        [Test]
        public void CheckIfGettingSpecifiedArticleForUserWorkingCorrectly()
        {
            using (var context = new DataContext(_dbContextOptions))
            {
                context.Articles.Add(new Articles() { ArticlesId = 1, Title = "test", Content = "test", PublicationDate = new DateTime(2022,01,01), UserId = 1});
                context.Users.Add(new User() { Id = 1, Nickname = "test", UserName = "test" });
                context.SaveChanges();
            }

            using (var context = new DataContext(_dbContextOptions))
            {
                var articlesRepository = new ArticlesRepository(context);
                var articles = articlesRepository.GetArticleForUser(1,1);

                Assert.AreEqual(1, articles.Result.ArticlesId);
                context.Database.EnsureDeleted();
            }
        }
        
        [Test]
        public void CheckIfGettingArticlesByUserIdWorkingCorrectly()
        {
            using (var context = new DataContext(_dbContextOptions))
            {
                context.Articles.Add(new Articles() { ArticlesId = 1, Title = "test1", Content = "test1", PublicationDate = new DateTime(2022,02,01), UserId = 1});
                context.Articles.Add(new Articles() { ArticlesId = 2, Title = "test2", Content = "test2", PublicationDate = new DateTime(2022,02,01), UserId = 2});
                context.Articles.Add(new Articles() { ArticlesId = 3, Title = "test3", Content = "test3", PublicationDate = new DateTime(2022,02,01), UserId = 3});
                context.Users.Add(new User() { Id = 1, Nickname = "test", UserName = "test" });
                context.SaveChanges();
            }
        
            using (var context = new DataContext(_dbContextOptions))
            {
                var articlesRepository = new ArticlesRepository(context);
                var articles = articlesRepository.GetArticleByUserId(1);
        
                Assert.AreEqual(1, articles.Result.Count());
                context.Database.EnsureDeleted();
            }
        }
    }
}
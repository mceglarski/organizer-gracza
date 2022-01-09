using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using organizer_gracza_backend.Data;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.UnitTests
{
    public class GamesTest
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
        public void CheckIfGetGameAsyncMethodReturnCorrectValue()
        {
            using (var context = new DataContext(_dbContextOptions))
            {
                context.Games.Add(new Game() { GameId = 1, Title = "tytuł"});
                context.SaveChanges();
            }

            using (var context = new DataContext(_dbContextOptions))
            {
                var gamesRepository = new GameRepository(context);
                var games = gamesRepository.GetGameAsync(1);

                Assert.AreEqual(1, games.Result.GameId);
                context.Database.EnsureDeleted();
            }
        }
        
        [Test]
        public void CheckIfGetGamesAsyncMethodReturnCorrectValue()
        {
            using (var context = new DataContext(_dbContextOptions))
            {
                context.Games.Add(new Game() { GameId = 1, Title = "tytuł1"});
                context.Games.Add(new Game() { GameId = 2, Title = "tytuł2"});
                context.Games.Add(new Game() { GameId = 3, Title = "tytuł3"});
                context.SaveChanges();
            }

            using (var context = new DataContext(_dbContextOptions))
            {
                var gamesRepository = new GameRepository(context);
                var games = gamesRepository.GetGamesAsync();

                Assert.AreEqual(3, games.Result.Count());
                context.Database.EnsureDeleted();
            }
        }
        
        [Test]
        public void CheckIfAddGamesAsyncMethodWorkingCorrectly()
        {
            var newGame = new Game()
            {
                GameId = 1,
                Title = "test",
            };

            using (var context = new DataContext(_dbContextOptions))
            {
                var gamesRepository = new GameRepository(context);
                var games = gamesRepository.GetGamesAsync();

                Assert.AreEqual(0, games.Result.Count());
            }

            using (var context = new DataContext(_dbContextOptions))
            {
                var gamesRepository = new GameRepository(context);
                gamesRepository.AddGame(newGame);
                context.SaveChanges();
            }

            using (var context = new DataContext(_dbContextOptions))
            {
                var gamesRepository = new GameRepository(context);
                var games = gamesRepository.GetGamesAsync();

                Assert.AreEqual(1, games.Result.Count());
                context.Database.EnsureDeleted();
            }
        }
        
        [Test]
        public void CheckIfDeleteGameMethodWorkingCorrectly()
        {
            using (var context = new DataContext(_dbContextOptions))
            {
                context.Games.Add(new Game() { GameId = 1, Title = "tytuł1"});
                context.Games.Add(new Game() { GameId = 2, Title = "tytuł2"});
                context.Games.Add(new Game() { GameId = 3, Title = "tytuł3"});
                context.SaveChanges();
            }

            using (var context = new DataContext(_dbContextOptions))
            {
                var gamesRepository = new GameRepository(context);
                var games = gamesRepository.GetGamesAsync();

                Assert.AreEqual(3, games.Result.Count());
            }

            using (var context = new DataContext(_dbContextOptions))
            {
                var gamesRepository = new GameRepository(context);
                foreach (var gameToDelete in context.Games.Where(x => x.GameId == 1))
                    gamesRepository.DeleteGame(gameToDelete);
                context.SaveChanges();
                var games = gamesRepository.GetGamesAsync();
                Assert.AreEqual(2, games.Result.Count());
                context.Database.EnsureDeleted();
            }
        }
    }
}
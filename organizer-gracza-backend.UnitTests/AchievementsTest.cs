using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using organizer_gracza_backend.Data;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.UnitTests
{
    public class AchievementsTest
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
        public void CheckIfGetAchievementByIdAsyncMethodReturnsCorrectValue()
        {
            using (var context = new DataContext(_dbContextOptions))
            {
                context.Achievements.Add(new Achievements { AchievementsId = 1, Details = "test1", Name = "test1" });
                context.SaveChanges();
            }

            using (var context = new DataContext(_dbContextOptions))
            {
                var achievementsRepository = new AchievementsRepository(context);
                var achievements = achievementsRepository.GetAchievementByIdAsync(1);

                Assert.AreEqual(1, achievements.Result.AchievementsId);
                context.Database.EnsureDeleted();
            }
        }

        [Test]
        public void CheckIfGetAchievementAsyncMethodReturnsCorrectValue()
        {
            using (var context = new DataContext(_dbContextOptions))
            {
                context.Achievements.Add(new Achievements { AchievementsId = 1, Details = "test1", Name = "test1" });
                context.Achievements.Add(new Achievements { AchievementsId = 2, Details = "test2", Name = "test2" });
                context.Achievements.Add(new Achievements { AchievementsId = 3, Details = "test3", Name = "test3" });
                context.SaveChanges();
            }

            using (var context = new DataContext(_dbContextOptions))
            {
                var achievementsRepository = new AchievementsRepository(context);
                var achievements = achievementsRepository.GetAchievementsAsync();

                Assert.AreEqual(3, achievements.Result.Count());
                context.Database.EnsureDeleted();
            }
        }

        [Test]
        public void CheckIfAddAchievementMethodWorkingCorrectly()
        {
            var newAchievement = new Achievements()
            {
                AchievementsId = 1,
                Name = "test",
                Details = "test"
            };

            using (var context = new DataContext(_dbContextOptions))
            {
                var achievementsRepository = new AchievementsRepository(context);
                var achievements = achievementsRepository.GetAchievementsAsync();

                Assert.AreEqual(0, achievements.Result.Count());
            }

            using (var context = new DataContext(_dbContextOptions))
            {
                var achievementsRepository = new AchievementsRepository(context);
                achievementsRepository.AddAchievement(newAchievement);
                context.SaveChanges();
            }

            using (var context = new DataContext(_dbContextOptions))
            {
                var achievementsRepository = new AchievementsRepository(context);
                var achievements = achievementsRepository.GetAchievementsAsync();

                Assert.AreEqual(1, achievements.Result.Count());
                context.Database.EnsureDeleted();
            }
        }

        [Test]
        public void CheckIfDeleteAchievementMethodWorkingCorrectly()
        {
            using (var context = new DataContext(_dbContextOptions))
            {
                context.Achievements.Add(new Achievements { AchievementsId = 1, Details = "test1", Name = "test1" });
                context.Achievements.Add(new Achievements { AchievementsId = 2, Details = "test2", Name = "test2" });
                context.Achievements.Add(new Achievements { AchievementsId = 3, Details = "test3", Name = "test3" });
                context.SaveChanges();
            }

            using (var context = new DataContext(_dbContextOptions))
            {
                var achievementsRepository = new AchievementsRepository(context);
                var achievements = achievementsRepository.GetAchievementsAsync();

                Assert.AreEqual(3, achievements.Result.Count());
            }

            using (var context = new DataContext(_dbContextOptions))
            {
                var achievementsRepository = new AchievementsRepository(context);
                foreach (var achievementToDelete in context.Achievements.Where(x => x.AchievementsId == 1))
                    achievementsRepository.DeleteAchievement(achievementToDelete);
                context.SaveChanges();
                var achievements = achievementsRepository.GetAchievementsAsync();
                Assert.AreEqual(2, achievements.Result.Count());
                context.Database.EnsureDeleted();
            }
        }
    }
}
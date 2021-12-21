using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using organizer_gracza_backend.DTOs;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Data
{
    public class Seed
    {
        public static async Task SeedUsers(UserManager<User> userManager, RoleManager<AppRole> roleManager)
        {
            if (await userManager.Users.AnyAsync())
                return;

            var userData = await System.IO.File.ReadAllTextAsync("Data/SeedData/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<User>>(userData);
            if (users == null)
                return;

            var roles = new List<AppRole>
            {
                new AppRole {Name = "Użytkownik"},
                new AppRole {Name = "Redaktor"},
                new AppRole {Name = "Moderator"},
                new AppRole {Name = "Admin"}
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }
            
            foreach (var user in users)
            {
                user.UserName = user.UserName.ToLower();
                await userManager.CreateAsync(user, "Pa$$w0rd");
                await userManager.AddToRoleAsync(user, "Użytkownik");
            }
        }

        public static async Task SeedGames(DataContext context)
        {
            if (await context.Games.AnyAsync())
                return;

            var gamesData = await System.IO.File.ReadAllTextAsync("Data/SeedData/GamesSeedData.json");
            var games = JsonSerializer.Deserialize<List<Game>>(gamesData);
            if (games == null)
                return;

            foreach (var game in games)
            {
                await context.AddAsync(game);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedEventsUser(DataContext context)
        {
            if (await context.EventUser.AnyAsync())
                return;
        
            var eventsData = await System.IO.File.ReadAllTextAsync("Data/SeedData/EventsUserSeedData.json");
            var events = JsonSerializer.Deserialize<List<EventUser>>(eventsData);
            if (events == null)
                return;
        
            foreach (var specifiedEvent in events)
            {
                await context.AddAsync(specifiedEvent);
            }
        
            await context.SaveChangesAsync();
        }
        public static async Task SeedEventsTeam(DataContext context)
        {
            if (await context.EventTeam.AnyAsync())
                return;
        
            var eventsData = await System.IO.File.ReadAllTextAsync("Data/SeedData/EventsTeamSeedData.json");
            var events = JsonSerializer.Deserialize<List<EventTeam>>(eventsData);
            if (events == null)
                return;
        
            foreach (var specifiedEvent in events)
            {
                await context.AddAsync(specifiedEvent);
            }
        
            await context.SaveChangesAsync();
        }

        public static async Task SeedEventsUserRegistrations(DataContext context)
        {
            if (await context.EventUserRegistration.AnyAsync())
                return;
        
            var eventsUserRegistrationsData =
                await System.IO.File.ReadAllTextAsync("Data/SeedData/EventsUserRegistrationsSeedData.json");
            var eventRegistrations = JsonSerializer.Deserialize<List<EventUserRegistration>>(eventsUserRegistrationsData);
            if (eventRegistrations == null)
                return;
        
            foreach (var eventRegistration in eventRegistrations)
            {
                await context.AddAsync(eventRegistration);
            }
        
            await context.SaveChangesAsync();
        }
        
        public static async Task SeedEventsTeamRegistrations(DataContext context)
        {
            if (await context.EventTeamRegistration.AnyAsync())
                return;
        
            var eventsTeamRegistrationsData =
                await System.IO.File.ReadAllTextAsync("Data/SeedData/EventsTeamRegistrationsSeedData.json");
            var eventRegistrations = JsonSerializer.Deserialize<List<EventTeamRegistration>>(eventsTeamRegistrationsData);
            if (eventRegistrations == null)
                return;
        
            foreach (var eventRegistration in eventRegistrations)
            {
                await context.AddAsync(eventRegistration);
            }
        
            await context.SaveChangesAsync();
        }
        
        public static async Task SeedTeams(DataContext context)
        {
            if (await context.Teams.AnyAsync())
                return;
        
            var teams =
                await System.IO.File.ReadAllTextAsync("Data/SeedData/TeamSeedData.json");
            var teamsData = JsonSerializer.Deserialize<List<Team>>(teams);
            if (teamsData == null)
                return;
        
            foreach (var team in teamsData)
            {
                await context.AddAsync(team);
            }
        
            await context.SaveChangesAsync();
        }
        
        public static async Task SeedTeamUsers(DataContext context)
        {
            if (await context.TeamUsers.AnyAsync())
                return;
        
            var teamUsers =
                await System.IO.File.ReadAllTextAsync("Data/SeedData/TeamUsersSeedData.json");
            var teamUsersData = JsonSerializer.Deserialize<List<TeamUser>>(teamUsers);
            if (teamUsersData == null)
                return;
        
            foreach (var teamUser in teamUsersData)
            {
                await context.AddAsync(teamUser);
            }
        
            await context.SaveChangesAsync();
        }
        
        public static async Task SeedAdmin(UserManager<User> userManager)
        {
           if( await userManager.Users.FirstOrDefaultAsync(x => x.UserName == "admin") != null)
                return;
            
           var admin = new User()
           {
               UserName = "admin",
               EventUserRegistration = null
           };
            
           await userManager.CreateAsync(admin, "Pa$$w0rd");
           await userManager.AddToRolesAsync(admin, new[] {"Admin", "Moderator", "Redaktor"});
            
        }
        
        public static async Task SeedGameStatistics(DataContext context)
        {
            if (await context.GameStatistics.AnyAsync())
                return;
        
            var gameStatistics =
                await System.IO.File.ReadAllTextAsync("Data/SeedData/GameStatisticsData.json");
            var gameStatisticsData = JsonSerializer.Deserialize<List<GameStatistics>>(gameStatistics);
            if (gameStatisticsData == null)
                return;
        
            foreach (var gamesStatistics in gameStatisticsData)
            {
                await context.AddAsync(gamesStatistics);
            }
        
            await context.SaveChangesAsync();
        }
        
        public static async Task SeedGeneralStatistics(DataContext context)
        {
            if (await context.GeneralStatistics.AnyAsync())
                return;
        
            var generalStatistics =
                await System.IO.File.ReadAllTextAsync("Data/SeedData/GeneralStatisticsData.json");
            var generalStatisticsData = JsonSerializer.Deserialize<List<GeneralStatistics>>(generalStatistics);
            if (generalStatisticsData == null)
                return;
        
            foreach (var generalStatistic in generalStatisticsData)
            {
                await context.AddAsync(generalStatistic);
            }
        
            await context.SaveChangesAsync();
        }
        
        public static async Task SeedAchievements(DataContext context)
        {
            if (await context.Achievements.AnyAsync())
                return;
        
            var achievements =
                await System.IO.File.ReadAllTextAsync("Data/SeedData/AchievementsSeedData.json");
            var achievementsData = JsonSerializer.Deserialize<List<Achievements>>(achievements);
            if (achievementsData == null)
                return;
        
            foreach (var achievement in achievementsData)
            {
                await context.AddAsync(achievement);
            }
        
            await context.SaveChangesAsync();
        }
        
        public static async Task SeedUserAchievementCounter(DataContext context)
        {
            if (await context.UserAchievementCounters.AnyAsync())
                return;
        
            var userAchievementsCounter =
                await System.IO.File.ReadAllTextAsync("Data/SeedData/UserAchievementCounterSeedData.json");
            var userAchievementCounterData = JsonSerializer.Deserialize<List<UserAchievementCounter>>
                (userAchievementsCounter);
            if (userAchievementCounterData == null)
                return;
        
            foreach (var userAchievementCounter in userAchievementCounterData)
            {
                await context.AddAsync(userAchievementCounter);
            }
        
            await context.SaveChangesAsync();
        }
        
        public static async Task SeedReminders(DataContext context)
        {
            if (await context.Reminder.AnyAsync())
                return;
        
            var reminders =
                await System.IO.File.ReadAllTextAsync("Data/SeedData/ReminderSeedData.json");
            var remindersData = JsonSerializer.Deserialize<List<Reminder>>
                (reminders);
            if (remindersData == null)
                return;
        
            foreach (var reminder in remindersData)
            {
                await context.AddAsync(reminder);
            }
        
            await context.SaveChangesAsync();
        }
        
        public static async Task SeedArticles(DataContext context)
        {
            if (await context.Articles.AnyAsync())
                return;
        
            var articles =
                await System.IO.File.ReadAllTextAsync("Data/SeedData/ArticlesSeedData.json");
            var articlesData = JsonSerializer.Deserialize<List<Articles>>
                (articles);
            if (articlesData == null)
                return;
        
            foreach (var article in articlesData)
            {
                await context.AddAsync(article);
            }
        
            await context.SaveChangesAsync();
        }
        
        public static async Task SeedForumThreads(DataContext context)
        {
            if (await context.ForumThread.AnyAsync())
                return;
        
            var forumThreads =
                await System.IO.File.ReadAllTextAsync("Data/SeedData/ForumThreadSeedData.json");
            var forumThreadsData = JsonSerializer.Deserialize<List<ForumThread>>
                (forumThreads);
            if (forumThreadsData == null)
                return;
        
            foreach (var forumThread in forumThreadsData)
            {
                await context.AddAsync(forumThread);
            }
        
            await context.SaveChangesAsync();
        }
        
        public static async Task SeedEventResults(DataContext context)
        {
            if (await context.EventResults.AnyAsync())
                return;
        
            var eventResults =
                await System.IO.File.ReadAllTextAsync("Data/SeedData/EventsResultsSeedData.json");
            var eventResultsData = JsonSerializer.Deserialize<List<EventResult>>
                (eventResults);
            if (eventResultsData == null)
                return;
        
            foreach (var eventResult in eventResultsData)
            {
                await context.AddAsync(eventResult);
            }
        
            await context.SaveChangesAsync();
        }
    }
}
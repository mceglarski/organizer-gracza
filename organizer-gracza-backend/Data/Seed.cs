using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;
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
    }
}
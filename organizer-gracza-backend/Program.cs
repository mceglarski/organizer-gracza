using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using organizer_gracza_backend.Data;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
           var host = CreateHostBuilder(args).Build();
           using var scope = host.Services.CreateScope();
           var services = scope.ServiceProvider;
           try
           {
               var context = services.GetRequiredService<DataContext>();
               var userManager = services.GetRequiredService<UserManager<User>>();
               var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
               await context.Database.MigrateAsync();
               await Seed.SeedGames(context);
               await Seed.SeedEventsUser(context);
               await Seed.SeedEventsTeam(context);
               await Seed.SeedUsers(userManager, roleManager);
               await Seed.SeedEventsUserRegistrations(context);
               await Seed.SeedTeams(context);
               await Seed.SeedTeamUsers(context);
               await Seed.SeedEventsTeamRegistrations(context);
               await Seed.SeedAdmin(userManager);
               await Seed.SeedGameStatistics(context);
               await Seed.SeedGeneralStatistics(context);
               await Seed.SeedAchievements(context);
               await Seed.SeedUserAchievementCounter(context);
               await Seed.SeedReminders(context);
               await Seed.SeedArticles(context);
               await Seed.SeedForumThreads(context);
               // await Seed.SeedForumPosts(context);
           }
           catch(Exception exception)
           {
               var logger = services.GetRequiredService<ILogger<Program>>();
               logger.LogError(exception, "An error occurred during migration");
           }

           await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
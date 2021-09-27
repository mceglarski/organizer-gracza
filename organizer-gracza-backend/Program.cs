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
               await Seed.SeedUsers(userManager, roleManager);
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
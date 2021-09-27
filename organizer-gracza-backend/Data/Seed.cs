using System.Collections.Generic;
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
            if(await userManager.Users.AnyAsync())
                return;

            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            var users = JsonSerializer.Deserialize <List<User>>(userData);
            if(users == null)
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

            var admin = new User()
            {
                UserName = "admin"
            };

            await userManager.CreateAsync(admin, "Pa$$w0rd");
            await userManager.AddToRolesAsync(admin, new[] {"Admin", "Moderator", "Redaktor"});
        }
    }
}
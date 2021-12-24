using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using organizer_gracza_backend.Data;
using organizer_gracza_backend.Helpers;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Services;
using organizer_gracza_backend.SignalR;

namespace organizer_gracza_backend.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<PresenceTracker>();
            services.Configure<CloudinarySettings>(configuration.GetSection("CloudinarySettings"));
            services.AddScoped<LogUserActivity>();
            services.AddScoped<DbContext, DataContext>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IEventTeamRepository, EventTeamRepository>();
            services.AddScoped<IEventUserRepository, EventUserRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPhotoEventService, PhotoEventService>();
            services.AddScoped<IEventTeamRegistrationRepository, EventTeamRegistrationRepository>();
            services.AddScoped<IEventUserRegistrationRepository, EventUserRegistrationRepository>();
            services.AddScoped<ITeamsRepository, TeamRepository>();
            services.AddScoped<ITeamUsersRepository, TeamUserRepository>();
            services.AddScoped<IGameStatisticsRepository, GameStatisticsRepository>();
            services.AddScoped<IGeneralStatisticsRepository, GeneralStatisticsRepository>();
            services.AddScoped<IAchievementsRepository, AchievementsRepository>();
            services.AddScoped<IUserAchievementCounterRepository, UserAchievementCounterRepository>();
            services.AddScoped<IReminderRepository, ReminderRepository>();
            services.AddScoped<IArticlesRepository, ArticlesRepository>();
            services.AddScoped<IForumThread, ForumThreadRepository>();
            services.AddScoped<IForumPost, ForumPostRepository>();
            services.AddScoped<IEventTeamResultRepository, EventTeamResultRepository>();
            services.AddScoped<IUserGamesRepository, UserGamesRepository>();
            services.AddScoped<IEventUserResultRepository, EventUserResultRepository>();
            services.AddScoped<IUserAchievementRepository, UserAchievementRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<DataContext>(options =>
            {
                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                string connStr;

                // Depending on if in development or production, use either Heroku-provided
                // connection string, or development connection string from env var.
                if (env == "Development")
                {
                    // Use connection string from file.
                    connStr = configuration.GetConnectionString("DefaultConnection");
                }
                else
                {
                    // Use connection string provided at runtime by Heroku.
                    var connUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

                    // Parse connection URL to connection string for Npgsql
                    connUrl = connUrl.Replace("postgres://", string.Empty);
                    var pgUserPass = connUrl.Split("@")[0];
                    var pgHostPortDb = connUrl.Split("@")[1];
                    var pgHostPort = pgHostPortDb.Split("/")[0];
                    var pgDb = pgHostPortDb.Split("/")[1];
                    var pgUser = pgUserPass.Split(":")[0];
                    var pgPass = pgUserPass.Split(":")[1];
                    var pgHost = pgHostPort.Split(":")[0];
                    var pgPort = pgHostPort.Split(":")[1];

                    connStr = $"Server={pgHost};Port={pgPort};User Id={pgUser};Password={pgPass};Database={pgDb};SSL Mode=Require;TrustServerCertificate=True";
                }

                // Whether the connection string came from the local development configuration file
                // or from the environment variable from Heroku, use it to set up your DbContext.
                options.UseNpgsql(connStr);            
            });

            return services;
        }
    }
}
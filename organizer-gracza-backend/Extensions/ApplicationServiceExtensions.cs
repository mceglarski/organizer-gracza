using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using organizer_gracza_backend.Data;
using organizer_gracza_backend.Helpers;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;
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
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}
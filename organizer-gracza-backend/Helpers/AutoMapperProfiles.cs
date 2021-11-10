using System;
using System.Linq;
using organizer_gracza_backend.DTOs;
using organizer_gracza_backend.Model;
using Profile = AutoMapper.Profile;

namespace organizer_gracza_backend.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, MemberDto>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                    opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url));
            CreateMap<User, EventUserRegistrationDto>()
                .ForPath(dest => dest.User.PhotoUrl, opt =>
                    opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url));
            CreateMap<Photo, PhotoDto>();
            CreateMap<MemberUpdateDto, User>();
            CreateMap<RegisterDto, User>();
            CreateMap<GameDto, Game>();
            CreateMap<Game, GameDto>();
            CreateMap<TeamDto, Team>();
            CreateMap<Team, TeamDto>();
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<EventUserDto, EventUser>();
            CreateMap<EventUser, EventUserDto>();
            CreateMap<EventTeamDto, EventTeam>();
            CreateMap<EventTeam, EventTeamDto>();
            CreateMap<EventUserRegistrationDto, EventUserRegistration>();
            CreateMap<EventUserRegistration, EventUserRegistrationDto>();
            CreateMap<EventTeamRegistrationDto, EventTeamRegistration>();
            CreateMap<EventTeamRegistration, EventTeamRegistrationDto>();
            CreateMap<TeamUser, TeamUsersDto>();
            CreateMap<User, ParticipiantDto>();
            CreateMap<Team, UsersInTeamsDto>();
            CreateMap<TeamUser, UsersTeamsDto>();
            CreateMap<GameStatistics, GameStatisticsDto>();
            CreateMap<GeneralStatistics, GeneralStatisticsDto>();
            CreateMap<Message, MessageDto>()
                .ForMember(dest => dest.SenderPhotoUrl,
                    opt => opt.MapFrom(
                        src => src.Sender.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(dest => dest.RecipientPhotoUrl,
                    opt => opt.MapFrom(
                        src => src.Recipient.Photos.FirstOrDefault(x => x.IsMain).Url));
            CreateMap<DateTime, DateTime>().ConvertUsing(d => DateTime.SpecifyKind(d, DateTimeKind.Utc));
        }
    }
}
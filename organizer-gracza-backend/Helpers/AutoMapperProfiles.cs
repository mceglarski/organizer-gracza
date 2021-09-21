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
            CreateMap<Photo, PhotoDto>();
            CreateMap<MemberUpdateDto, User>();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using organizer_gracza_backend.DTOs;
using organizer_gracza_backend.Helpers;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Interfaces
{
    public interface IUserRepository
    {
        void Update(User user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<User>> GetUsersAsync();
        Task<MemberDto> GetUserByIdAsync(int id);
        Task<User> GetUserByUsernameAsync(string username);
        Task<PagedList<MemberDto>> GetMembersAsync(PaginationParams paginationParams);
        Task<MemberDto> GetMemberAsync(string username);

    }
}
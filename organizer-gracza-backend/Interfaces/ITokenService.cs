using System.Threading.Tasks;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
        
    }
}
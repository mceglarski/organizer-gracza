using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
        
    }
}
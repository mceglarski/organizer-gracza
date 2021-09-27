using Microsoft.AspNetCore.Identity;

namespace organizer_gracza_backend.Model
{
    public class UserRole : IdentityUserRole<int>
    {
        public User User { get; set; }
        public AppRole Role { get; set; }
    }
}
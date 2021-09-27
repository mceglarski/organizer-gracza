using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace organizer_gracza_backend.Model
{
    public class AppRole : IdentityRole<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
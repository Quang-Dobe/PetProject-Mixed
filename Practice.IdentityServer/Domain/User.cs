using Microsoft.AspNetCore.Identity;

namespace Server.Domain
{
    public class User : IdentityUser
    {
        public string? Initials { get; set; }
    }
}

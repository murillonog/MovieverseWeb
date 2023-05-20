using Microsoft.AspNetCore.Identity;

namespace MovieverseWeb.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
        public string Email { get; set; }
    }
}

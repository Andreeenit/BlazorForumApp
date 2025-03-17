using Microsoft.AspNetCore.Identity;

namespace BlazorForum.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}

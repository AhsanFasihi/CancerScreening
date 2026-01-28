using Microsoft.AspNetCore.Identity;
namespace CancerScreening.Persistence.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;

namespace WEB_953505_MANKEVICH.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public byte[] AvatarImage { get; set; }
    }
}
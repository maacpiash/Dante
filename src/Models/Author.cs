using Microsoft.AspNetCore.Identity;

namespace Dante.Models
{
    public class Author : IdentityUser
    {
        public string Name { get; set; }
    }
}

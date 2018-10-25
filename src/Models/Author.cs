using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Dante.Models
{
    public class Author : IdentityUser
    {
        public string Name { get; set; }     
        public List<Activity> Activities { get; set; }
        public List<Author> Followers { get; set; }
        public List<Author> Following { get; set; }
        public byte[] ProfilePicture { get; set; }
    }
}

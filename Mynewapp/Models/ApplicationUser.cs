using Microsoft.AspNetCore.Identity;
using System;

namespace Mynewapp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegisteredDate { get; set; }
        public DateTime LastLoginDate { get; set; }
    }
}

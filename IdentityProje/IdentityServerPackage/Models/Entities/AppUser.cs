using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerPackage.Models.Entities
{
    public class AppUser : IdentityUser
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? AccessTokenExpiration { get; set; }

        public DateTime? RefreshTokenExpiration { get; set; }

        public bool? IsActive { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerPackage.Models.Response.AppUser
{
    public class ResponseResultAppUser
    {
        public string Message { get; set; }

        public string StatusCode { get; set; }

        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public string AccessTokenExpiration { get; set; }

        public string RefreshTokenExpiration { get; set; }

        public string Error { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}

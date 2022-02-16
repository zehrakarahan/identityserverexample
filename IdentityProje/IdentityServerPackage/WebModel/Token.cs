﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerPackage.WebModel
{
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpiration { get; set; }

        public DateTime RefreshTokenExpiration { get; set; }
        public string RefreshToken { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string RoleName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}

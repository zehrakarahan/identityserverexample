using FluentValidation;
using IdentityServerPackage.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerPackage.Models.Request.AppUser
{
    public class RequestUpdateAppUser 
    {
        public int Id { get; set; }

        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public DateTime? AccessTokenExpiration { get; set; }

        public DateTime? RefreshTokenExpiration { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
    public class RequestUpdateAppUserValidator : AbstractValidator<RequestUpdateAppUser>
    {
        public RequestUpdateAppUserValidator()
        {
            //RuleFor(x => x).NotNull();
            //RuleFor(x => x.Name).NotEmpty().MaximumLength(150);
            //RuleFor(x => x.Address).MaximumLength(350);
            //RuleFor(x => x.City).MaximumLength(50);
            //RuleFor(x => x.District).MaximumLength(80);
        }
    }

}

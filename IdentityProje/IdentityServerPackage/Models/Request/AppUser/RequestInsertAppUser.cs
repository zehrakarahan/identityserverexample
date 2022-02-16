using FluentValidation;
using IdentityServerPackage.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerPackage.Models.Request.AppUser
{
    public class RequestInsertAppUser
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public DateTime? AccessTokenExpiration { get; set; }

        public DateTime? RefreshTokenExpiration { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
    public class RequestInsertAppUserValidator : AbstractValidator<RequestInsertAppUser>
    {
        public RequestInsertAppUserValidator()
        {
            //RuleFor(x => x).NotNull();
            //RuleFor(x => x.Name).NotEmpty().MaximumLength(150);
            ////RuleFor(x => x.Id).NotNull();
            ////RuleFor(x => x.ModifiedBy).NotNull();
            //RuleFor(x => x.UserId).NotNull();
        }
    }
}

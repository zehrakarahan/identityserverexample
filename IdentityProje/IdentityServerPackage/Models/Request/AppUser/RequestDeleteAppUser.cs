using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using IdentityServerPackage.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerPackage.Models.Request.AppUser
{
    public class RequestDeleteAppUser 
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }
    }
    public class RequestDeleteAppUserValidator : AbstractValidator<RequestDeleteAppUser>
    {
        public RequestDeleteAppUserValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}

using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using IdentityServerPackage.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerPackage.Models.Request.FirmaKullanici
{
    public class RequestDeleteFirmaKullanici : BaseRequest
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }

    }
    public class RequestDeleteFirmaKullaniciValidator : AbstractValidator<RequestDeleteFirmaKullanici>
    {
        public RequestDeleteFirmaKullaniciValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}

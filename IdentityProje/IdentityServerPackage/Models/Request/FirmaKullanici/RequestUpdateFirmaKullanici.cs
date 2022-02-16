using FluentValidation;
using IdentityServerPackage.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerPackage.Models.Request.FirmaKullanici
{
    public class RequestUpdateFirmaKullanici : BaseRequest
    {
        public int Id { get; set; }

        public bool? IsActive { get; set; }

        public string UserGid { get; set; }

        public string LisansGid { get; set; }

        public string FirmaSubeGid { get; set; }

    }
    public class RequestUpdateFirmaKullaniciValidator : AbstractValidator<RequestUpdateFirmaKullanici>
    {
        public RequestUpdateFirmaKullaniciValidator()
        {
            //RuleFor(x => x).NotNull();
            //RuleFor(x => x.Name).NotEmpty().MaximumLength(150);
            //RuleFor(x => x.Address).MaximumLength(350);
            //RuleFor(x => x.City).MaximumLength(50);
            //RuleFor(x => x.District).MaximumLength(80);
        }
    }
}

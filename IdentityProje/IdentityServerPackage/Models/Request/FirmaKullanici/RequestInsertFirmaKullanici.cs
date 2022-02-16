using FluentValidation;
using IdentityServerPackage.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerPackage.Models.Request.FirmaKullanici
{
    public class RequestInsertFirmaKullanici : BaseRequest
    {
        public string UserGid { get; set; }

        public string LisansGid { get; set; }

        public string FirmaSubeGid { get; set; }

    
    }
    public class RequestInsertFirmaKullaniciValidator : AbstractValidator<RequestInsertFirmaKullanici>
    {
        public RequestInsertFirmaKullaniciValidator()
        {
            //RuleFor(x => x).NotNull();
            //RuleFor(x => x.Name).NotEmpty().MaximumLength(150);
            ////RuleFor(x => x.Id).NotNull();
            ////RuleFor(x => x.ModifiedBy).NotNull();
            //RuleFor(x => x.UserId).NotNull();
        }
    }
}

using FluentValidation;
using IdentityServerPackage.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerPackage.Models.Request.Lisans
{
    public class RequestUpdateLisans:BaseRequest
    {

        public int Id { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string LisansNo { get; set; }

        public string Gid { get; set; }
    }
    public class RequestUpdateLisansValidator : AbstractValidator<RequestUpdateLisans>
    {
        public RequestUpdateLisansValidator()
        {
            //RuleFor(x => x).NotNull();
            //RuleFor(x => x.Name).NotEmpty().MaximumLength(150);
            //RuleFor(x => x.Address).MaximumLength(350);
            //RuleFor(x => x.City).MaximumLength(50);
            //RuleFor(x => x.District).MaximumLength(80);
        }
    }
}

using FluentValidation;
using IdentityServerPackage.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerPackage.Models.Request.Lisans
{
    public class RequestInsertLisans : BaseRequest
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string LisansNo { get; set; }

        public string Gid { get; set; }

 

    }
    public class RequestInsertLisansValidator : AbstractValidator<RequestInsertLisans>
    {
        public RequestInsertLisansValidator()
        {
            //RuleFor(x => x).NotNull();
            //RuleFor(x => x.Name).NotEmpty().MaximumLength(150);
            ////RuleFor(x => x.Id).NotNull();
            ////RuleFor(x => x.ModifiedBy).NotNull();
            //RuleFor(x => x.UserId).NotNull();
        }
    }
}

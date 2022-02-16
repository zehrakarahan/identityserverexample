using IdentityServerPackage.Models.Entities.Base.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerPackage.Models.Entities
{
    public class Lisans : ActiveOnEntityBase
    {
        public string Gid { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string LisansNo { get; set; }

        public string UserId { get; set; }


    }
}

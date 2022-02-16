using IdentityServerPackage.Models.Entities.Base.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerPackage.Models.Entities
{
    public class FirmaKullanici : ActiveOnEntityBase
    {
        public string UserGid { get; set; }

        public string LisansGid { get; set; }

        public string FirmaSubeGid { get; set; }

        public string UserId { get; set; }
    }
}

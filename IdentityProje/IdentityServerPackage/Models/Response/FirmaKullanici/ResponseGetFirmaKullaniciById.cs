using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerPackage.Models.Response.FirmaKullanici
{
    public class ResponseGetFirmaKullaniciById
    {
        public int Id { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string ModifiedBy { get; set; }

        public string UserGid { get; set; }

        public string LisansGid { get; set; }

        public string FirmaSubeGid { get; set; }

        public string UserId { get; set; }
    }
}

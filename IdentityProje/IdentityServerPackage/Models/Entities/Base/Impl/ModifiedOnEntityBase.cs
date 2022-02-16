using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerPackage.Models.Entities.Base.Impl
{
    public class ModifiedOnEntityBase : CreateOnEntityBase
    {
        public virtual DateTime? ModifiedOn { get; set; }
        public virtual string ModifiedBy { get; set; }

        public virtual void ModifiedOnAuditing(string modifiedBy)
        {
            ModifiedOn = DateTime.Now;
            if (string.IsNullOrEmpty(modifiedBy))
                return;
            ModifiedBy = modifiedBy;
        }
    }
}

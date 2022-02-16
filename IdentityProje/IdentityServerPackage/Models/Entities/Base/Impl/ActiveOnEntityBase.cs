using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerPackage.Models.Entities.Base.Impl
{
    [Serializable]
    public abstract class ActiveOnEntityBase : DeleteOnEntityBase
    {
        public virtual bool IsActive { get; set; }
        public virtual void IsActiveAuditing(bool isActive, string modifiedBy)
        {
            this.IsActive = isActive;
            base.ModifiedOnAuditing(modifiedBy);
        }
    }
}

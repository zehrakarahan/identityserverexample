using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerPackage.Models.Entities.Base.Impl
{
    public class CreateOnEntityBase : EntityBase
    {
        [Required]
        public virtual DateTime CreatedOn { get; set; }
        public virtual string CreatedBy { get; set; }

        public virtual void CreatedOnAuditing(string createdBy)
        {
            CreatedOn = DateTime.Now;
            if (string.IsNullOrEmpty(createdBy))
                return;
            CreatedBy = createdBy;
        }
    }
}

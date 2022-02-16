using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IdentityServerPackage.Models.Entities.Base.Impl
{
    public class DeleteOnEntityBase : ModifiedOnEntityBase, ISoftDelete
    {
        [Required, DefaultValue(false)]
        public virtual bool IsDeleted { get; set; }
        public virtual void DeletionAuditing(string modifiedBy)
        {
            IsDeleted = true;
            ModifiedOnAuditing(modifiedBy);
        }
    }
    public interface ISoftDelete
    {
        [JsonIgnore, Column("isdeleted")]
        bool IsDeleted { get; }
    }
}

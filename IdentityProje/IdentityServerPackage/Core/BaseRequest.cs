using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IdentityServerPackage.Core
{
    public class BaseRequest
    {
        [JsonIgnore]
        internal string UserId { get; set; }
    }
}

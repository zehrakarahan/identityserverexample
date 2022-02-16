using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IdentityServerPackage.Core.Error
{
    public interface IServiceResult
    {
        [JsonPropertyName("code")]
        string Code { get; }
        [JsonPropertyName("message")]
        string Message { get; }
    }
}

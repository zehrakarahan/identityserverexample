using IdentityServerPackage.Core.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace IdentityServerPackage.Core
{
    public class BaseResponse<T> where T : new()
    {
        public bool HasError { get { return Errors.Any(); } }
        public List<IServiceResult> Errors { get; set; } = new List<IServiceResult>();
        public HttpStatusCode StatusCode { get; set; }
        public T Data { get; set; } = new T();
    }
}

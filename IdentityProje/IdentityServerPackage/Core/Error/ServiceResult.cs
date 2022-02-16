using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerPackage.Core.Error
{
    public class ServiceResult : IServiceResult
    {
        public string Code { get; protected set; }
        public string Message { get; protected set; }

        public ServiceResult(string message, string code = null)
        {
            Message = message;
            Code = code;
        }

        protected ServiceResult()
        {
        }
    }
}

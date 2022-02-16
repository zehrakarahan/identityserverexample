using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace IdentityServerPackage.Core.Error
{
    public class ValidationResult : IActionResult
    {
        private readonly List<IServiceResult> _serviceErrors = new List<IServiceResult>();

        protected ValidationResult()
        {
        }

        public ValidationResult(List<ServiceResult> errors)
        {
            _serviceErrors.AddRange(errors);
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            context.HttpContext.Response.StatusCode = 400;
            context.HttpContext.Response.ContentType = "application/json; charset=utf-8";
            await context.HttpContext.Response.WriteAsync(JsonSerializer.Serialize(_serviceErrors));
        }
    }
}

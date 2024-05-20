using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Common.Errors
{
    public interface IExceptionService
    {
        public HttpStatusCode statusCode { get; }
        public string ErrorMessage { get; }
    }
}

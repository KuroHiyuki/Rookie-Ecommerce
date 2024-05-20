using EcommerceWeb.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.WebApi.Controllers
{
    public class ErrorController : ControllerBase
    {
        [Route("/errorHandle")]
        public IActionResult Error()
        {
            Exception exception = HttpContext.Features.Get<IExceptionHandlerFeature>()!.Error;
            var (statusCode, message) = exception switch
            {
                IExceptionService exceptionService => ((int)exceptionService.statusCode, exceptionService.ErrorMessage),
                _ => (StatusCodes.Status500InternalServerError, "An unexpected error ccourred.")
            };
            return Problem(statusCode: statusCode, title: message);
        }
    }
}

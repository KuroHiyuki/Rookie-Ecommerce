using EcommerceWeb.WebApi.Common.Const;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.WebApi.Controllers
{
    [ApiController]
    public class APIController : ControllerBase
    {
        protected IActionResult Problem(List<ErrorOr.Error> errors)
        {
            HttpContext.Items[HttpContextKeyItems.errors] = errors;
            var firstError = errors[0];
            var statusCodeHandle = firstError.Type switch
            {
                ErrorOr.ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorOr.ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorOr.ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError,
            };
            return Problem(statusCode: statusCodeHandle, title: firstError.Description);
        }
    }
}

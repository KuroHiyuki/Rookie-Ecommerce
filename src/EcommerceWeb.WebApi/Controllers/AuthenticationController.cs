using EcommerceWeb.Application.Authentication.Common.Response;
using EcommerceWeb.Application.Authentication.Errors;
using EcommerceWeb.Application.Authentication.Login;
using EcommerceWeb.Application.Authentication.Register;
using EcommerceWeb.Domain.Common.Enum;
using EcommerceWeb.Presentation.Authutentication;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.WebApi.Controllers
{
    [Route("auth/[controller]")]
    public class AuthenticationController : APIController
    {
        private readonly ISender _mediator;

        public AuthenticationController(ISender mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = new RegisterCommand(request.FirstName,
                                              request.LastName,
                                              request.Email,
                                              request.Password,
                                              (Sex)request.Sex,
                                              request.Birthday,
                                              request.NumberPhone,
                                              request.Address);
            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);
            return authResult.Match(
                authResult => Ok(),
                errors => Problem(errors));
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            //var query = _mapper.Map<LoginQuery>(request);
            var query = new LoginQuery(request.Email, request.Password);
            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);
            if (authResult.IsError && authResult.FirstError == Errors.UserAuthentication.InvalidCredentials)
            {
                return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
            }
            return authResult.Match(
                authResult => Ok(authResult),
                errors => Problem(errors));
        }
    }
}

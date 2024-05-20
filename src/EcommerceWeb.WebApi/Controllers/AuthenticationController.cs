using EcommerceWeb.Application.Authentication.Commands.Register;
using EcommerceWeb.Application.Authentication.Common.Response;
using EcommerceWeb.Application.Authentication.Errors;
using EcommerceWeb.Application.Authentication.Queries.Login;
using EcommerceWeb.Presentation.Authutentication;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.WebApi.Controllers
{
    [Route("auth/[controller]")]
    public class AuthenticationController : APIController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public AuthenticationController(ISender mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);
            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);
            return authResult.Match(
                authResult => Ok(),
                errors => Problem(errors));
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);

            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);
            if (authResult.IsError && authResult.FirstError == Errors.UserAuthentication.InvalidCredentials)
            {
                return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
            }
            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors));
        }
    }
}

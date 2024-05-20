using EcommerceWeb.Application.Authentication.Common.Interfaces;
using EcommerceWeb.Application.Authentication.Common.Response;
using EcommerceWeb.Domain.Entities;
using ErrorOr;
using MediatR;

namespace EcommerceWeb.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler(
        IJwtTokenGenerator _jwtTokenGenerator,
        IAuthenticationRepository _authenticationRepository) : 
        IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            if (_authenticationRepository.GetByEmail(query.Email) is not Customer user)
            {
                return Errors.Errors.UserAuthentication.InvalidCredentials;
            }

            if (user.Password != query.Password)
            {
                return Errors.Errors.UserAuthentication.InvalidCredentials;
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}

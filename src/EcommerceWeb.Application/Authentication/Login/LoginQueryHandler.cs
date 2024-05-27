using EcommerceWeb.Application.Authentication.Common.Interfaces;
using EcommerceWeb.Application.Authentication.Common.Response;
using EcommerceWeb.Domain.Entities;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Reflection;

namespace EcommerceWeb.Application.Authentication.Login
{
    public class LoginQueryHandler(
        IJwtTokenGenerator _jwtTokenGenerator,
        IAuthenticationRepository _authenticationRepository,
        IPasswordHasher<User> _passwordHasher) :
        IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            if (_authenticationRepository.GetByEmail(query.Email) is not User user)
            {
                return Errors.Errors.UserAuthentication.InvalidCredentials;
            }

            if (_passwordHasher.VerifyHashedPassword(user, user.PasswordHash!, query.Password) == PasswordVerificationResult.Failed)
            {
                return Errors.Errors.UserAuthentication.InvalidCredentials;
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user.Id,user.FirstName!,user.LastName!,user.Email!,user.AvatarUrl!,token,user.PhoneNumber!,user.Address!);
        }
    }
}

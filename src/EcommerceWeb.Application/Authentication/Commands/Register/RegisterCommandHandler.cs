using EcommerceWeb.Application.Authentication.Common.Interfaces;
using EcommerceWeb.Application.Authentication.Common.Response;
using EcommerceWeb.Domain.Entities;
using ErrorOr;
using MediatR;


namespace EcommerceWeb.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler(
        IJwtTokenGenerator _jwtTokenGenerator,
        IAuthenticationRepository _authenticationRepository) : 
        IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            if (_authenticationRepository.GetByEmail(command.Email) is not null)
            {
                return Errors.Errors.EmailAlreadyUse.EmailExists;
            }
            var user = new Customer
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password,
                Sex = command.Sex,
                BirthDate = command.Birthday
            };

            var token = _jwtTokenGenerator.GenerateToken(user);
            user.AccessToken = token;

            _authenticationRepository.Add(user);
            
            return new AuthenticationResult(user, token);
        }
    }
}

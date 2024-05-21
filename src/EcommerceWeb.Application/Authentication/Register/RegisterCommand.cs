using EcommerceWeb.Application.Authentication.Common.Response;
using EcommerceWeb.Domain.Common.Enum;
using ErrorOr;
using MediatR;

namespace EcommerceWeb.Application.Authentication.Register
{
    public record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password,
        Sex Sex,
        DateTime Birthday) : IRequest<ErrorOr<AuthenticationResult>>;
}


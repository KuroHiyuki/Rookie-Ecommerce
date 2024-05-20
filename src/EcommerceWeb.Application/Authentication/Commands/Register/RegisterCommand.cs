using EcommerceWeb.Application.Authentication.Common.Response;
using EcommerceWeb.Domain.Common.Enum;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password,
        Sex Sex,
        DateTime Birthday) : IRequest<ErrorOr<AuthenticationResult>>;
}


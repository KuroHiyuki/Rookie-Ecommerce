using EcommerceWeb.Application.Authentication.Common.Response;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Authentication.Login
{
    public record LoginQuery(
       string Email,
       string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}

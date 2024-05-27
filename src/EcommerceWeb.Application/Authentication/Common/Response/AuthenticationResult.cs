using EcommerceWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Authentication.Common.Response
{
    public record AuthenticationResult(
        string Id,
        string FirstName,
        string LastName,
        string Email,
        string AvatarURL,
        string Token,
        string NumberPhone,
        string Address
        );
}

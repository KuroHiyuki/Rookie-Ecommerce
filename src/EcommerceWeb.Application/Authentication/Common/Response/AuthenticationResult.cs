using EcommerceWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Authentication.Common.Response
{
    public record AuthenticationResult(
        Customer User,
        string Token
        );
}

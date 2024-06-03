using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Users.GetUserByEmail
{
    public record GetUserByEmailQuery(string Email) :IRequest<bool>
    {
    }
}

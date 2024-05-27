using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Users.DeleteUser
{
    public record DeleteUserCommand(string UserId) : IRequest
    {
    }
}

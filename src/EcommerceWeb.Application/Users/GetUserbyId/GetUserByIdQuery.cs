using EcommerceWeb.Application.Users.Common.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Users.GetUserbyId
{
    public record GetUserByIdQuery(string UserId): IRequest<UserModelAppLayer>
    {
    }
}

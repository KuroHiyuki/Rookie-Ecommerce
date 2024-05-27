using EcommerceWeb.Application.Users.Common.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Users.GetList
{
    public record GetUserListQuery : IRequest<List<UserModelAppLayer>>
    {
    }
}

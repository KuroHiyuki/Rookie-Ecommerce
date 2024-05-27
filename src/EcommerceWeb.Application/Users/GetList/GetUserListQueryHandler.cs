using EcommerceWeb.Application.Users.Common.Repository;
using EcommerceWeb.Application.Users.Common.Response;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Users.GetList
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserModelAppLayer>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserListQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserModelAppLayer>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var userList = await _userRepository.GetUsersListAsync();
            var Lists = userList.Select(u => new UserModelAppLayer
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Address = u.Address,
                AvatarURL = u.AvatarUrl,
                NumberPhone = u.PhoneNumber
            }).ToList();
            if(Lists is null)
            {
                return [];
            }
            return Lists!;
        }
    }
}

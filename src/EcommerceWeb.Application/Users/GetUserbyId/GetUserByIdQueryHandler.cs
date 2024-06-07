using EcommerceWeb.Application.Users.Common.Repository;
using EcommerceWeb.Application.Users.Common.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Users.GetUserbyId
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserModelAppLayer>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserModelAppLayer> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.UserId);
            return new UserModelAppLayer
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address,
                AvatarURL = user.AvatarUrl,
                NumberPhone = user.PhoneNumber
            };
        }
    }
}

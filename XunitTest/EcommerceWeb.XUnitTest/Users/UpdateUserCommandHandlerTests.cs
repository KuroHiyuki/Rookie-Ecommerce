using EcommerceWeb.Application.Users.Common.Repository;
using EcommerceWeb.Application.Users.Common.Response;
using EcommerceWeb.Application.Users.UpdateUser;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.XUnitTest.Users
{
    public class UpdateUserCommandHandlerTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly UpdateUserCommandHandler _handler;

        public UpdateUserCommandHandlerTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _handler = new UpdateUserCommandHandler(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldCallUpdateUserAsync_WithCorrectUserIdAndModel()
        {
            // Arrange
            var userId = "123";
            var model = new UserUpdateModel
            {
                FirstName = "John",
                LastName = "Doe",
                Address = "123 Main St",
                AvatarURL = "avatar.jpg",
                NumberPhone = "123456789"
            };
            var command = new UpdateUserCommand(userId, model);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _userRepositoryMock.Verify(repo => repo.UpdateUserAsync(userId, model), Times.Once);
        }
    }
}

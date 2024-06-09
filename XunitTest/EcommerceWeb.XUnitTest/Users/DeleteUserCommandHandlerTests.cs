using EcommerceWeb.Application.Users.Common.Repository;
using EcommerceWeb.Application.Users.DeleteUser;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.XUnitTest.Users
{
    public class DeleteUserCommandHandlerTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly DeleteUserCommandHandler _handler;

        public DeleteUserCommandHandlerTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _handler = new DeleteUserCommandHandler(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldCallDeleteUserAsync_WithCorrectUserId()
        {
            // Arrange
            var userId = "123";
            var command = new DeleteUserCommand(userId);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _userRepositoryMock.Verify(repo => repo.DeleteUserAsync(userId), Times.Once);
        }
    }
}


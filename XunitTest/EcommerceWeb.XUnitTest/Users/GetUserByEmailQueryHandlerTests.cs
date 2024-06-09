using EcommerceWeb.Application.Users.Common.Repository;
using EcommerceWeb.Application.Users.GetUserByEmail;
using EcommerceWeb.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.XUnitTest.Users
{
    public class GetUserByEmailQueryHandlerTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly GetUserByEmailQueryHandler _handler;

        public GetUserByEmailQueryHandlerTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _handler = new GetUserByEmailQueryHandler(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnTrue_WhenUserExistsWithEmail()
        {
            // Arrange
            var email = "test@example.com";
            var query = new GetUserByEmailQuery(email);
            _userRepositoryMock.Setup(repo => repo.GetUserByEmailAsync(email)).ReturnsAsync(new User());

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Handle_ShouldReturnFalse_WhenUserDoesNotExistWithEmail()
        {
            // Arrange
            var email = "nonexistent@example.com";
            var query = new GetUserByEmailQuery(email);
            _userRepositoryMock.Setup(repo => repo.GetUserByEmailAsync(email)).ReturnsAsync((User)null);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.False(result);
        }
    }
}

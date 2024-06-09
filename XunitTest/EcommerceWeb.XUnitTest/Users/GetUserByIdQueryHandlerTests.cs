using EcommerceWeb.Application.Users.Common.Repository;
using EcommerceWeb.Application.Users.GetUserbyId;
using EcommerceWeb.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.XUnitTest.Users
{
    public class GetUserByIdQueryHandlerTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly GetUserByIdQueryHandler _handler;

        public GetUserByIdQueryHandlerTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _handler = new GetUserByIdQueryHandler(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_Should_Return_User_By_Id()
        {
            // Arrange
            var userId = "user123";
            var user = new User
            {
                Id = userId,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Address = "123 Main St",
                AvatarUrl = "http://example.com/avatar.jpg",
                PhoneNumber = "123-456-7890"
            };

            _userRepositoryMock.Setup(repo => repo.GetUserByIdAsync(userId))
                .ReturnsAsync(user);

            var query = new GetUserByIdQuery(userId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.Id, result.Id);
            Assert.Equal(user.FirstName, result.FirstName);
            Assert.Equal(user.LastName, result.LastName);
            Assert.Equal(user.Email, result.Email);
            Assert.Equal(user.Address, result.Address);
            Assert.Equal(user.AvatarUrl, result.AvatarURL);
            Assert.Equal(user.PhoneNumber, result.NumberPhone);
        }

        [Fact]
        public async Task Handle_Should_Throw_Exception_When_User_Not_Found()
        {
            // Arrange
            var userId = "nonExistentUser";
            _userRepositoryMock.Setup(repo => repo.GetUserByIdAsync(userId))
                .ReturnsAsync((User)null);

            var query = new GetUserByIdQuery(userId);

            // Act & Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => _handler.Handle(query, CancellationToken.None));
        }
    }
}

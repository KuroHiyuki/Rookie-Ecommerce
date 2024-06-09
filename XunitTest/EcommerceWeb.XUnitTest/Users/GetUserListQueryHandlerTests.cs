using EcommerceWeb.Application.Users.Common.Repository;
using EcommerceWeb.Application.Users.GetList;
using EcommerceWeb.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.XUnitTest.Users
{
    public class GetUserListQueryHandlerTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly GetUserListQueryHandler _handler;

        public GetUserListQueryHandlerTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _handler = new GetUserListQueryHandler(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnUserList_WhenUsersExist()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = "1", FirstName = "John", LastName = "Doe", Email = "john@example.com", Address = "123 Main St", AvatarUrl = "avatar.jpg", PhoneNumber = "123456789" },
                new User { Id = "2", FirstName = "Jane", LastName = "Doe", Email = "jane@example.com", Address = "456 Elm St", AvatarUrl = "avatar2.jpg", PhoneNumber = "987654321" }
            };
            _userRepositoryMock.Setup(repo => repo.GetUsersListAsync()).ReturnsAsync(users);

            var query = new GetUserListQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("John", result[0].FirstName);
            Assert.Equal("Doe", result[0].LastName);
            Assert.Equal("john@example.com", result[0].Email);
            Assert.Equal("123 Main St", result[0].Address);
            Assert.Equal("avatar.jpg", result[0].AvatarURL);
            Assert.Equal("123456789", result[0].NumberPhone);

            Assert.Equal("Jane", result[1].FirstName);
            Assert.Equal("Doe", result[1].LastName);
            Assert.Equal("jane@example.com", result[1].Email);
            Assert.Equal("456 Elm St", result[1].Address);
            Assert.Equal("avatar2.jpg", result[1].AvatarURL);
            Assert.Equal("987654321", result[1].NumberPhone);
        }
    }
}

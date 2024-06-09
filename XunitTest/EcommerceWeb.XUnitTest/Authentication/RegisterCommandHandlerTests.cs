using EcommerceWeb.Application.Authentication.Common.Interfaces;
using EcommerceWeb.Application.Authentication.Register;
using EcommerceWeb.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Moq;
using ErrorOr;

namespace EcommerceWeb.XUnitTest.Authentication
{
    public class RegisterCommandHandlerTests
    {
        [Fact]
        public async Task Handle_Should_Return_Error_When_Email_Already_Exists()
        {
            // Arrange
            var mockJwtTokenGenerator = new Mock<IJwtTokenGenerator>();
            var mockAuthenticationRepository = new Mock<IAuthenticationRepository>();
            var mockPasswordHasher = new Mock<IPasswordHasher<User>>();

            var handler = new RegisterCommandHandler(mockJwtTokenGenerator.Object, mockAuthenticationRepository.Object, mockPasswordHasher.Object);
            var command = new RegisterCommand("John", "Doe", "john.doe@example.com", "password123", "1234567890", "123 Main St");

            mockAuthenticationRepository.Setup(repo => repo.GetByEmail(command.Email)).Returns(new User());

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.IsError);

        }

        [Fact]
        public async Task Handle_Should_Register_New_User_And_Return_AuthenticationResult()
        {
            // Arrange
            var mockJwtTokenGenerator = new Mock<IJwtTokenGenerator>();
            var mockAuthenticationRepository = new Mock<IAuthenticationRepository>();
            var mockPasswordHasher = new Mock<IPasswordHasher<User>>();

            var handler = new RegisterCommandHandler(mockJwtTokenGenerator.Object, mockAuthenticationRepository.Object, mockPasswordHasher.Object);
            var command = new RegisterCommand("John", "Doe", "john.doe@example.com", "password123", "1234567890", "123 Main St");

            mockAuthenticationRepository.Setup(repo => repo.GetByEmail(command.Email)).Returns((User)null);
            mockPasswordHasher.Setup(hasher => hasher.HashPassword(It.IsAny<User>(), command.Password)).Returns(command.Password);
            mockJwtTokenGenerator.Setup(generator => generator.GenerateToken(It.IsAny<User>())).Returns("test_token");

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result.IsError);
            Assert.NotNull(result.Value);
            Assert.Equal(command.FirstName, result.Value.FirstName);
            Assert.Equal(command.LastName, result.Value.LastName);
            Assert.Equal(command.Email, result.Value.Email);

        }
    }
}

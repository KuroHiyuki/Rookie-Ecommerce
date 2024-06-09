using EcommerceWeb.Application.Authentication.Common.Interfaces;
using EcommerceWeb.Application.Authentication.Login;
using EcommerceWeb.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.XUnitTest.Authentication
{
    public class AuthenticationTest
    {
        [Fact]
        public async Task Handle_ValidCredentials_ShouldReturnAuthenticationResult()
        {
            // Arrange
            var email = "test@example.com";
            var password = "password";
            var user = new User
            {
                Id = "1",
                FirstName = "John",
                LastName = "Doe",
                Email = email,
                AvatarUrl = "avatar.jpg",
                PhoneNumber = "123456789",
                Address = "123 Main St",
                PasswordHash = "hashed_password" // replace with actual hashed password
            };

            var jwtTokenGeneratorMock = new Mock<IJwtTokenGenerator>();
            jwtTokenGeneratorMock.Setup(mock => mock.GenerateToken(user)).Returns("mock_token");

            var authenticationRepositoryMock = new Mock<IAuthenticationRepository>();
            authenticationRepositoryMock.Setup(mock => mock.GetByEmail(email)).Returns(user);

            var passwordHasherMock = new Mock<IPasswordHasher<User>>();
            passwordHasherMock.Setup(mock => mock.VerifyHashedPassword(user, user.PasswordHash, password)).Returns(PasswordVerificationResult.Success);

            var handler = new LoginQueryHandler(jwtTokenGeneratorMock.Object, authenticationRepositoryMock.Object, passwordHasherMock.Object);
            var query = new LoginQuery(email, password);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            var authenticationResult = result.Value;
            Assert.Equal(user.Id, authenticationResult.Id);
            Assert.Equal(user.FirstName, authenticationResult.FirstName);
            Assert.Equal(user.LastName, authenticationResult.LastName);
            Assert.Equal(user.Email, authenticationResult.Email);
            Assert.Equal(user.AvatarUrl, authenticationResult.AvatarURL);
            Assert.Equal("mock_token", authenticationResult.Token);
            Assert.Equal(user.PhoneNumber, authenticationResult.NumberPhone);
            Assert.Equal(user.Address, authenticationResult.Address);
        }
    }
}

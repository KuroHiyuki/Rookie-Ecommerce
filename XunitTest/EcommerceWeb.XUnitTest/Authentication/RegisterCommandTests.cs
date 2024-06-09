using EcommerceWeb.Application.Authentication.Common.Response;
using EcommerceWeb.Application.Authentication.Register;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.XUnitTest.Authentication
{
    public class RegisterCommandTests
    {
        [Fact]
        public void RegisterCommand_Should_Have_Correct_Properties()
        {
            // Arrange
            var firstName = "John";
            var lastName = "Doe";
            var email = "john.doe@example.com";
            var password = "password123";
            var numberPhone = "1234567890";
            var address = "123 Main St";

            // Act
            var command = new RegisterCommand(firstName, lastName, email, password, numberPhone, address);

            // Assert
            Assert.Equal(firstName, command.FirstName);
            Assert.Equal(lastName, command.LastName);
            Assert.Equal(email, command.Email);
            Assert.Equal(password, command.Password);
            Assert.Equal(numberPhone, command.NumberPhone);
            Assert.Equal(address, command.Address);
        }

        [Fact]
        public void RegisterCommand_Should_Implement_IRequest()
        {
            // Arrange
            var command = new RegisterCommand("John", "Doe", "john.doe@example.com", "password123", "1234567890", "123 Main St");

            // Act & Assert
            Assert.IsAssignableFrom<IRequest<ErrorOr<AuthenticationResult>>>(command);
        }

        [Fact]
        public void RegisterCommand_Should_Support_Equality()
        {
            // Arrange
            var command1 = new RegisterCommand("John", "Doe", "john.doe@example.com", "password123", "1234567890", "123 Main St");
            var command2 = new RegisterCommand("John", "Doe", "john.doe@example.com", "password123", "1234567890", "123 Main St");

            // Act & Assert
            Assert.Equal(command1, command2);
            Assert.True(command1 == command2);
        }

        [Fact]
        public void RegisterCommand_Should_Support_Copying()
        {
            // Arrange
            var originalCommand = new RegisterCommand("John", "Doe", "john.doe@example.com", "password123", "1234567890", "123 Main St");
            var copiedCommand = originalCommand with { Email = "jane.doe@example.com" };

            // Act & Assert
            Assert.NotEqual(originalCommand, copiedCommand);
            Assert.Equal("jane.doe@example.com", copiedCommand.Email);
            Assert.Equal(originalCommand.FirstName, copiedCommand.FirstName);
        }
    }
}

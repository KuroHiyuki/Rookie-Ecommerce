using EcommerceWeb.Application.Authentication.Register;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.XUnitTest.Authentication
{
    public class RegisterCommandValidatorTests
    {
        private readonly RegisterCommandValidator _validator;

        public RegisterCommandValidatorTests()
        {
            _validator = new RegisterCommandValidator();
        }

        [Fact]
        public void Should_Have_Error_When_FirstName_Is_Empty()
        {
            // Arrange
            var command = new RegisterCommand("", "Doe", "john.doe@example.com", "password123", "1234567890", "123 Main St");

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.FirstName);
        }

        [Fact]
        public void Should_Have_Error_When_LastName_Is_Empty()
        {
            // Arrange
            var command = new RegisterCommand("John", "", "john.doe@example.com", "password123", "1234567890", "123 Main St");

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.LastName);
        }

        [Fact]
        public void Should_Have_Error_When_Email_Is_Empty()
        {
            // Arrange
            var command = new RegisterCommand("John", "Doe", "", "password123", "1234567890", "123 Main St");

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void Should_Have_Error_When_Password_Is_Empty()
        {
            // Arrange
            var command = new RegisterCommand("John", "Doe", "john.doe@example.com", "", "1234567890", "123 Main St");

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Password);
        }

        [Fact]
        public void Should_Not_Have_Error_When_All_Fields_Are_Valid()
        {
            // Arrange
            var command = new RegisterCommand("John", "Doe", "john.doe@example.com", "password123", "1234567890", "123 Main St");

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.FirstName);
            result.ShouldNotHaveValidationErrorFor(x => x.LastName);
            result.ShouldNotHaveValidationErrorFor(x => x.Email);
            result.ShouldNotHaveValidationErrorFor(x => x.Password);
        }
    }
}

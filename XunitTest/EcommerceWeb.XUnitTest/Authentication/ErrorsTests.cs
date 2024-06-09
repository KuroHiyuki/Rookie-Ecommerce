using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.XUnitTest.Authentication
{
    public class ErrorsTests
    {
        [Fact]
        public void EmailAlreadyUse_EmailExists_Should_Return_Correct_Error()
        {
            // Arrange
            var expectedCode = "User.EmailExists.";
            var expectedDescription = "Email is already in use.";

            // Act
            var error = Application.Authentication.Errors.Errors.EmailAlreadyUse.EmailExists;

            // Assert
            Assert.Equal(expectedCode, error.Code);
            Assert.Equal(expectedDescription, error.Description);
            Assert.Equal(ErrorType.Conflict, error.Type);
        }

        [Fact]
        public void UserAuthentication_InvalidCredentials_Should_Return_Correct_Error()
        {
            // Arrange
            var expectedCode = "Authentication.InvalidCredentials";
            var expectedDescription = "Invalid Credentitals.";

            // Act
            var error = Application.Authentication.Errors.Errors.UserAuthentication.InvalidCredentials;

            // Assert
            Assert.Equal(expectedCode, error.Code);
            Assert.Equal(expectedDescription, error.Description);
            Assert.Equal(ErrorType.Validation, error.Type);
        }
    }
}

using EcommerceWeb.Application.Authentication.Common.Errors;
using EcommerceWeb.Application.Common.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.XUnitTest.Authentication
{
    public class EmailExistHandlerTests
    {
        [Fact]
        public void EmailExistHandler_Should_Return_Correct_StatusCode()
        {
            // Arrange
            var handler = new EmailExistHandler();

            // Act
            var statusCode = handler.statusCode;

            // Assert
            Assert.Equal(HttpStatusCode.Conflict, statusCode);
        }

        [Fact]
        public void EmailExistHandler_Should_Return_Correct_ErrorMessage()
        {
            // Arrange
            var handler = new EmailExistHandler();

            // Act
            var errorMessage = handler.ErrorMessage;

            // Assert
            Assert.Equal("Email already exists.", errorMessage);
        }

        [Fact]
        public void EmailExistHandler_Should_Be_Of_Type_Exception()
        {
            // Arrange
            var handler = new EmailExistHandler();

            // Act & Assert
            Assert.IsAssignableFrom<Exception>(handler);
        }

        [Fact]
        public void EmailExistHandler_Should_Implement_IExceptionService()
        {
            // Arrange
            var handler = new EmailExistHandler();

            // Act & Assert
            Assert.IsAssignableFrom<IExceptionService>(handler);
        }
    }
}

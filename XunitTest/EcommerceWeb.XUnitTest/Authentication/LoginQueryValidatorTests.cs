using EcommerceWeb.Application.Authentication.Login;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.XUnitTest.Authentication
{
    public class LoginQueryValidatorTests
    {
        private readonly LoginQueryValidator _validator;

        public LoginQueryValidatorTests()
        {
            _validator = new LoginQueryValidator();
        }

        [Fact]
        public void Should_Have_Error_When_Email_Is_Empty()
        {
            var model = new LoginQuery ( string.Empty,  "password" );
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Email).WithErrorMessage("Email is required.");
        }

        [Fact]
        public void Should_Have_Error_When_Password_Is_Empty()
        {
            var model = new LoginQuery ("test@example.com", string.Empty);
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Password).WithErrorMessage("Password is required.");
        }

        [Fact]
        public void Should_Not_Have_Error_When_Fields_Are_Valid()
        {
            var model = new LoginQuery ("test@example.com", "password");
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Email);
            result.ShouldNotHaveValidationErrorFor(x => x.Password);
        }
    }
}

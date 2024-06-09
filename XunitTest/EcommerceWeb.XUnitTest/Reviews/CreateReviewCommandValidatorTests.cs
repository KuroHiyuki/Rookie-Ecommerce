using EcommerceWeb.Application.Reviews.CreateReview;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.XUnitTest.Reviews
{
    public class CreateReviewCommandValidatorTests
    {
        private readonly CreateReviewCommandValidator _validator;

        public CreateReviewCommandValidatorTests()
        {
            _validator = new CreateReviewCommandValidator();
        }

        [Fact]
        public void Should_Have_Error_When_UserId_Is_Empty()
        {
            var command = new CreateReviewCommand(
                UserId: string.Empty,
                ProductId: "product123",
                Comment: "Great product!",
                Rating: 5);

            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.UserId);
        }

        [Fact]
        public void Should_Have_Error_When_ProductId_Is_Empty()
        {
            var command = new CreateReviewCommand(
                UserId: "user123",
                ProductId: string.Empty,
                Comment: "Great product!",
                Rating: 5);

            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.ProductId);
        }

        [Fact]
        public void Should_Have_Error_When_Rating_Is_Empty()
        {
            var command = new CreateReviewCommand(
                UserId: "user123",
                ProductId: "product123",
                Comment: "Great product!",
                Rating: 0);

            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.Rating);
        }

        [Fact]
        public void Should_Have_Error_When_Rating_Is_Out_Of_Range()
        {
            var command = new CreateReviewCommand(
                UserId: "user123",
                ProductId: "product123",
                Comment: "Great product!",
                Rating: 6);

            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.Rating);
        }

        [Fact]
        public void Should_Have_Error_When_Comment_Is_Empty()
        {
            var command = new CreateReviewCommand(
                UserId: "user123",
                ProductId: "product123",
                Comment: string.Empty,
                Rating: 5);

            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.Comment);
        }

        [Fact]
        public void Should_Have_Error_When_Comment_Exceeds_MaxLength()
        {
            var command = new CreateReviewCommand(
                UserId: "user123",
                ProductId: "product123",
                Comment: new string('a', 501), // 501 characters
                Rating: 5);

            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.Comment);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Command_Is_Valid()
        {
            var command = new CreateReviewCommand(
                UserId: "user123",
                ProductId: "product123",
                Comment: "Great product!",
                Rating: 5);

            var result = _validator.TestValidate(command);
            result.ShouldNotHaveValidationErrorFor(x => x.UserId);
            result.ShouldNotHaveValidationErrorFor(x => x.ProductId);
            result.ShouldNotHaveValidationErrorFor(x => x.Rating);
            result.ShouldNotHaveValidationErrorFor(x => x.Comment);
        }
    }
}

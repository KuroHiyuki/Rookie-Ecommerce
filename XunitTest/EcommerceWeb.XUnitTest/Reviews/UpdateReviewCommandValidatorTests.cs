using EcommerceWeb.Application.Reviews.UpdateReview;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.XUnitTest.Reviews
{
    public class UpdateReviewCommandValidatorTests
    {
        private readonly UpdateReviewCommandValidator _validator;

        public UpdateReviewCommandValidatorTests()
        {
            _validator = new UpdateReviewCommandValidator();
        }

        [Fact]
        public void Should_Have_Error_When_ReviewId_Is_Empty()
        {
            var command = new UpdateReviewCommand(
                UserId: "user123",
                ReviewId: string.Empty,
                Comment: "Good product.",
                Rating: 4);

            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.ReviewId);
        }

        [Fact]
        public void Should_Have_Error_When_Rating_Is_Empty()
        {
            var command = new UpdateReviewCommand(
                UserId: "user123",
                ReviewId: "review123",
                Comment: "Good product.",
                Rating: 0);

            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.Rating);
        }

        [Fact]
        public void Should_Have_Error_When_Rating_Is_Out_Of_Range()
        {
            var command = new UpdateReviewCommand(
                UserId: "user123",
                ReviewId: "review123",
                Comment: "Good product.",
                Rating: 6);

            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.Rating);
        }

        [Fact]
        public void Should_Have_Error_When_Comment_Is_Empty()
        {
            var command = new UpdateReviewCommand(
                UserId: "user123",
                ReviewId: "review123",
                Comment: string.Empty,
                Rating: 4);

            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.Comment);
        }

        [Fact]
        public void Should_Have_Error_When_Comment_Exceeds_MaxLength()
        {
            var command = new UpdateReviewCommand(
                UserId: "user123",
                ReviewId: "review123",
                Comment: new string('a', 501), // 501 characters
                Rating: 4);

            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.Comment);
        }

        [Fact]
        public void Should_Not_Have_Error_When_ReviewId_Rating_And_Comment_Are_Valid()
        {
            var command = new UpdateReviewCommand(
                UserId: "user123",
                ReviewId: "review123",
                Comment: "Good product.",
                Rating: 4);

            var result = _validator.TestValidate(command);
            result.ShouldNotHaveValidationErrorFor(x => x.ReviewId);
            result.ShouldNotHaveValidationErrorFor(x => x.Rating);
            result.ShouldNotHaveValidationErrorFor(x => x.Comment);
        }
    }
}

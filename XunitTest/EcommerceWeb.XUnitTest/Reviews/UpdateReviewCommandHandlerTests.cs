using EcommerceWeb.Application.Reviews.Common.Repository;
using EcommerceWeb.Application.Reviews.UpdateReview;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.XUnitTest.Reviews
{
    public class UpdateReviewCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidReviewId_ShouldUpdateReview()
        {
            // Arrange
            var reviewId = "review123";
            var userId = "user456";
            var rating = 4;
            var comment = "Updated comment";

            var reviewRepositoryMock = new Mock<IReviewRepository>();
            var handler = new UpdateReviewCommandHandler(reviewRepositoryMock.Object);
            var command = new UpdateReviewCommand(userId, reviewId, comment, rating);

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            reviewRepositoryMock.Verify(repo => repo.UpdateReviewAsync(userId, reviewId, rating, comment), Times.Once);
        }
    }
}

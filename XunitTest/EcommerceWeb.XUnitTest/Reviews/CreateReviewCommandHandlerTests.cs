using EcommerceWeb.Application.Reviews.Common.Repository;
using EcommerceWeb.Application.Reviews.CreateReview;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.XUnitTest.Reviews
{
    public class CreateReviewCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidCommand_ShouldAddReview()
        {
            // Arrange
            var userId = "user123";
            var productId = "product456";
            var rating = 4;
            var comment = "This is a great product!";
            var command = new CreateReviewCommand(userId, productId, rating, comment);
            var reviewRepositoryMock = new Mock<IReviewRepository>();
            var handler = new CreateReviewCommandHandler(reviewRepositoryMock.Object);

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            reviewRepositoryMock.Verify(repo => repo.AddReviewAsync(userId, productId, rating, comment), Times.Once);
        }
    }
}

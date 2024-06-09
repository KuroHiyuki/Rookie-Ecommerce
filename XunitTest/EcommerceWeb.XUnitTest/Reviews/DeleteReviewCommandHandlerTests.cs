using EcommerceWeb.Application.Common.Interface;
using EcommerceWeb.Application.Reviews.Common.Repository;
using EcommerceWeb.Application.Reviews.DeleteReview;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.XUnitTest.Reviews
{
    public class DeleteReviewCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidCommand_ShouldDeleteReview()
        {
            // Arrange
            var userId = "user123";
            var reviewId = "review456";
            var command = new DeleteReviewCommand(userId, reviewId);

            var reviewRepositoryMock = new Mock<IReviewRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var handler = new DeleteReviewCommandHandler(reviewRepositoryMock.Object, unitOfWorkMock.Object);

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            reviewRepositoryMock.Verify(repo => repo.DeleteReviewAsync(userId, reviewId), Times.Once);
            unitOfWorkMock.Verify(uow => uow.SaveAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}

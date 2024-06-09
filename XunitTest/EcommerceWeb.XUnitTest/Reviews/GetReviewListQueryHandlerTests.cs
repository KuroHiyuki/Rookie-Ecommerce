using EcommerceWeb.Application.Reviews.Common.Repository;
using EcommerceWeb.Application.Reviews.GetReviewList;
using EcommerceWeb.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.XUnitTest.Reviews
{
    public class GetReviewListQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ValidRequest_ShouldReturnReviewList()
        {
            // Arrange
            var reviews = new List<Review>
            {
                new Review { Id = "1", ProductId = "product123", Rating = 5, Comment = "Great product", CreatedAt = DateTime.Now, UpdateAt = DateTime.Now, UserId = "user456", User = new User { FirstName = "John", LastName = "Doe" } },
                new Review { Id = "2", ProductId = "product456", Rating = 4, Comment = "Good quality", CreatedAt = DateTime.Now, UpdateAt = DateTime.Now, UserId = "user789", User = new User { FirstName = "Jane", LastName = "Doe" } }
            };

            var reviewRepositoryMock = new Mock<IReviewRepository>();
            reviewRepositoryMock.Setup(repo => repo.GetReviewsListAsync()).ReturnsAsync(reviews);

            var handler = new GetReviewListQueryHandler(reviewRepositoryMock.Object);

            var query = new GetReivewListQuery();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);

            var firstReview = result[0];
            Assert.Equal("1", firstReview.Id);
            Assert.Equal("product123", firstReview.ProductId);
            Assert.Equal(5, firstReview.Rating);
            Assert.Equal("Great product", firstReview.Commnet);
            Assert.Equal("John Doe", firstReview.UserName);

            var secondReview = result[1];
            Assert.Equal("2", secondReview.Id);
            Assert.Equal("product456", secondReview.ProductId);
            Assert.Equal(4, secondReview.Rating);
            Assert.Equal("Good quality", secondReview.Commnet);
            Assert.Equal("Jane Doe", secondReview.UserName);
        }
    }
}

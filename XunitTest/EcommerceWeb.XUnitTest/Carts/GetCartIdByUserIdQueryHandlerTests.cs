using EcommerceWeb.Application.Carts.Common.Repositories;
using EcommerceWeb.Application.Carts.GetCartIdByUser;
using Moq;
using EcommerceWeb.Domain.Entities;

namespace EcommerceWeb.XUnitTest.Carts
{
    public class GetCartIdByUserIdQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnCartId_WhenCartExistsForUser()
        {
            // Arrange
            var userId = "user123";
            var cartId = "cart123";

            var query = new GetCartIdByUserIdQuery(userId);

            var cartRepositoryMock = new Mock<ICartRepository>();
            cartRepositoryMock.Setup(repo => repo.GetCartByUserId(userId)).ReturnsAsync(new Cart { Id = cartId });

            var handler = new GetCartidByUserIdQueryHandler(cartRepositoryMock.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal(cartId, result);
        }

        public async Task Handle_ShouldReturnMessage_WhenCartDoesNotExistForUser()
        {
            // Arrange
            var userId = "user123";

            var query = new GetCartIdByUserIdQuery(userId);

            var cartRepositoryMock = new Mock<ICartRepository>();
            cartRepositoryMock.Setup(repo => repo.GetCartByUserId(userId)).ReturnsAsync((Cart)null);

            var handler = new GetCartidByUserIdQueryHandler(cartRepositoryMock.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal($"User Id {userId} hasn't added any product to the cart yet", result);
        }
    }
}

using EcommerceWeb.Application.Carts.Common.Repositories;
using EcommerceWeb.Application.Carts.Common.Response;
using EcommerceWeb.Application.Carts.GetProductInCart;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.XUnitTest.Carts
{
    public class GetProductCartByUserIdQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnProductList_WhenCartExistsForUser()
        {
            // Arrange
            var userId = "user123";
            var cartId = "cart123";
            var productList = new List<CartModelAppLayer>
            {
                new CartModelAppLayer { ProductId = "1", Name = "Product 1", Description = "Description 1", Price = 10.0m, Quantity = 2, Images = "image1.jpg" },
                new CartModelAppLayer { ProductId = "2", Name = "Product 2", Description = "Description 2", Price = 15.0m, Quantity = 1, Images = "image2.jpg" }
            };

            var query = new GetProductCartByUserIdQuery(cartId, userId);

            var cartRepositoryMock = new Mock<ICartRepository>();
            cartRepositoryMock.Setup(repo => repo.GetProductsInCart(cartId, userId)).ReturnsAsync(productList);

            var handler = new GetProductCartByUserIdQueryHandler(cartRepositoryMock.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(productList.Count, result.Count);

            for (int i = 0; i < productList.Count; i++)
            {
                Assert.Equal(productList[i].ProductId, result[i].ProductId);
                Assert.Equal(productList[i].Name, result[i].Name);
                Assert.Equal(productList[i].Description, result[i].Description);
                Assert.Equal(productList[i].Price, result[i].Price);
                Assert.Equal(productList[i].Quantity, result[i].Quantity);
                Assert.Equal(productList[i].Images, result[i].Images);
            }
        }

        [Fact]
        public async Task Handle_ShouldReturnEmptyList_WhenCartDoesNotExistForUser()
        {
            // Arrange
            var userId = "user123";
            var cartId = "cart123";

            var query = new GetProductCartByUserIdQuery(cartId, userId);

            var cartRepositoryMock = new Mock<ICartRepository>();
            cartRepositoryMock.Setup(repo => repo.GetProductsInCart(cartId, userId)).ReturnsAsync(new List<CartModelAppLayer>());

            var handler = new GetProductCartByUserIdQueryHandler(cartRepositoryMock.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}

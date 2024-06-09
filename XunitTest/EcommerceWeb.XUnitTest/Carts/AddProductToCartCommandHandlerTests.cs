using EcommerceWeb.Application.Carts.AddProduct;
using EcommerceWeb.Application.Carts.Common.Repositories;
using EcommerceWeb.Application.Common.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.XUnitTest.Carts
{
    public class AddProductToCartCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldAddProductToCartAndSaveChanges_WhenCalled()
        {
            // Arrange
            var userId = "user123";
            var productId = "product123";
            var quantity = 2;

            var command = new AddProductToCartCommand(productId, quantity, userId);

            var cartRepositoryMock = new Mock<ICartRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var handler = new AddProductToCartCommandHandler(cartRepositoryMock.Object, unitOfWorkMock.Object);

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            cartRepositoryMock.Verify(repo => repo.AddProductToCart(userId, productId, quantity), Times.Once);
            unitOfWorkMock.Verify(uow => uow.SaveAsync(CancellationToken.None), Times.Once);
        }
    }
}

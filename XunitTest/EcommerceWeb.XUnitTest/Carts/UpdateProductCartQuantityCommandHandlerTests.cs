using EcommerceWeb.Application.Carts.Common.Repositories;
using EcommerceWeb.Application.Carts.UpdateProductQuantity;
using EcommerceWeb.Application.Common.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.XUnitTest.Carts
{
    public class UpdateProductCartQuantityCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldUpdateProductQuantityInCart_WhenProductExistsInCart()
        {
            // Arrange
            var cartId = "cart123";
            var productId = "product123";
            var newQuantity = 5;

            var command = new UpdateProductCartQuantityCommand(cartId, productId, newQuantity);

            var cartRepositoryMock = new Mock<ICartRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var handler = new UpdateProductCartQuantityCommandHandler(cartRepositoryMock.Object, unitOfWorkMock.Object);

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            cartRepositoryMock.Verify(repo => repo.UpdateProductQuantity(cartId, productId, newQuantity), Times.Once);
            unitOfWorkMock.Verify(uow => uow.SaveAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}

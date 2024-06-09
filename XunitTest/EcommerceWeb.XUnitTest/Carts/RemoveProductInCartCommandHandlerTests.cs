using EcommerceWeb.Application.Carts.Common.Repositories;
using EcommerceWeb.Application.Carts.RemoveProductInCart;
using EcommerceWeb.Application.Common.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.XUnitTest.Carts
{
    public class RemoveProductInCartCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldRemoveProductFromCart_WhenProductExistsInCart()
        {
            var cartId = "cart123";
            var productId = "product123";

            var command = new RemoveProductInCartCommand(cartId, productId);

            var cartRepositoryMock = new Mock<ICartRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            cartRepositoryMock.Setup(repo => repo.DeleteProductFromCart(cartId, productId))
                              .Returns(Task.CompletedTask); 

            var handler = new RemoveProductInCartCommandHandler(cartRepositoryMock.Object, unitOfWorkMock.Object);

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            cartRepositoryMock.Verify(repo => repo.DeleteProductFromCart(cartId, productId), Times.Once);
            unitOfWorkMock.Verify(uow => uow.SaveAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}

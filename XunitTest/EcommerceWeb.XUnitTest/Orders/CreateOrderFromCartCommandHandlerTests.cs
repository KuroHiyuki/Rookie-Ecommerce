using EcommerceWeb.Application.Common.Interface;
using EcommerceWeb.Application.Orders.Common.Repository;
using EcommerceWeb.Application.Orders.CreateOrderFromCart;
using EcommerceWeb.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.XUnitTest.Orders
{
    public class CreateOrderFromCartCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldCreateOrderFromCartAndSaveChanges()
        {
            // Arrange
            var userId = "user123";
            var command = new CreateOrderFromCartCommand(userId);

            var orderRepositoryMock = new Mock<IOrderRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            // Thiết lập hành vi của orderRepositoryMock
            orderRepositoryMock.Setup(repo => repo.CreateOrderFromCartAsync(userId))
                .ReturnsAsync(new Order()); // Trả về một order giả định

            var handler = new CreateOrderFromCartCommandHandler(orderRepositoryMock.Object, unitOfWorkMock.Object);

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            orderRepositoryMock.Verify(repo => repo.CreateOrderFromCartAsync(userId), Times.Once);
            unitOfWorkMock.Verify(uow => uow.SaveAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}

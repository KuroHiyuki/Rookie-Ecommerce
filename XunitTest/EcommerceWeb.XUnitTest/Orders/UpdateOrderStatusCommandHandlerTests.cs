using EcommerceWeb.Application.Orders.Common.Repository;
using EcommerceWeb.Application.Orders.UpdateOrderStatus;
using EcommerceWeb.Domain.Common.Enum;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.XUnitTest.Orders
{
    public class UpdateOrderStatusCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidCommand_ShouldUpdateOrderStatus()
        {
            // Arrange
            var orderId = "1";
            var newStatus = OrderStatus.InFulfillment;
            var command = new UpdateOrderStatusCommand(orderId, newStatus);
            var orderRepositoryMock = new Mock<IOrderRepository>();
            var handler = new UpdateOrderStatusCommandHandler(orderRepositoryMock.Object);

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            orderRepositoryMock.Verify(repo => repo.UpdateOrderStatusAsync(orderId, newStatus), Times.Once);
        }
    }
}

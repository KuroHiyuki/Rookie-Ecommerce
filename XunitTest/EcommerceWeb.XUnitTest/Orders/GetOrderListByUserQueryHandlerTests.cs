using EcommerceWeb.Application.Orders.Common.Repository;
using EcommerceWeb.Application.Orders.GetorderByUserId;
using EcommerceWeb.Domain.Common.Enum;
using EcommerceWeb.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.XUnitTest.Orders
{
    public class GetOrderListByUserQueryHandlerTests
    {
        private readonly GetOrderListByUserQueryHandler _handler;
        private readonly Mock<IOrderRepository> _orderRepositoryMock;

        public GetOrderListByUserQueryHandlerTests()
        {
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _handler = new GetOrderListByUserQueryHandler(_orderRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnOrderList_WhenOrdersExist()
        {
            // Arrange
            var userId = "user1";
            var orders = new List<Order>
            {
                new Order
                {
                    UserName = "User 1",
                    Address = "Address 1",
                    TelephoneNumber = "123456789",
                    PaymentMethod = PaymentMethod.COD,
                    Status = OrderStatus.OrderPlaced,
                    TotalAmount = 100,
                    Note = "Note 1",
                    Details = new List<OrderDetail>
                    {
                        new OrderDetail
                        {
                            ProductId = "product1",
                            Product = new Product { Name = "Product 1", ImageURL = "image1.jpg" },
                            UnitPrice = 50,
                            Quantity = 2
                        }
                    }
                }
            };

            _orderRepositoryMock.Setup(repo => repo.GetOrderByIdAsync(userId))
                                .ReturnsAsync(orders);

            var query = new GetOrderListByUserQuery(userId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);

            var expectedOrder = orders[0];
            var actualOrder = result[0];

            Assert.Equal(expectedOrder.UserName, actualOrder.UserName);
            Assert.Equal(expectedOrder.Address, actualOrder.Address);
            Assert.Equal(expectedOrder.TelephoneNumber, actualOrder.NumberPhone);
            Assert.Equal(expectedOrder.PaymentMethod, actualOrder.method);
            Assert.Equal(expectedOrder.Status, actualOrder.status);
            Assert.Equal(expectedOrder.TotalAmount, actualOrder.TotalAmount);
            Assert.Equal(expectedOrder.Note, actualOrder.Note);

            var expectedDetails = expectedOrder.Details.ToList();
            var actualDetails = actualOrder.products;

            Assert.Equal(expectedDetails.Count, actualDetails.Count);

            for (int i = 0; i < expectedDetails.Count; i++)
            {
                var expectedDetail = expectedDetails[i];
                var actualDetail = actualDetails[i];

                Assert.Equal(expectedDetail.ProductId, actualDetail.ProductId);
                Assert.Equal(expectedDetail.Product.Name, actualDetail.ProductName);
                Assert.Equal(expectedDetail.UnitPrice, actualDetail.UnitPrice);
                Assert.Equal(expectedDetail.Quantity, actualDetail.Quantity);
                Assert.Equal(expectedDetail.Product.ImageURL, actualDetail.ImageURL);
            }
        }
    }
}

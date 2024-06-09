using EcommerceWeb.Application.Orders.Common.Repository;
using EcommerceWeb.Application.Orders.GetOrderList;
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
    public class GetOrderListQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnOrderList_WhenOrdersExist()
        {
            // Arrange
            var orders = new List<Order>
            {
                new Order
                {
                    UserName = "User1",
                    Address = "Address1",
                    TelephoneNumber = "123456789",
                    PaymentMethod = PaymentMethod.COD,
                    Status = OrderStatus.OrderPlaced,
                    TotalAmount = 100,
                    Note = "Note1",
                    Details = new List<OrderDetail>
                    {
                        new OrderDetail
                        {
                            ProductId = "1",
                            Product = new Product { Name = "Product1", ImageURL = "Image1.jpg" },
                            UnitPrice = 50,
                            Quantity = 2
                        },
                        new OrderDetail
                        {
                            ProductId = "2",
                            Product = new Product { Name = "Product2", ImageURL = "Image2.jpg" },
                            UnitPrice = 30,
                            Quantity = 3
                        }
                    }
                }
            };

            var orderRepositoryMock = new Mock<IOrderRepository>();
            orderRepositoryMock.Setup(repo => repo.GetOrdersListAsync())
                               .ReturnsAsync(orders);

            var handler = new GetOrderListQueryHandler(orderRepositoryMock.Object);

            var query = new GetOrderListQuery();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Count);

            var orderModel = result.First();
            Assert.Equal("User1", orderModel.UserName);
            Assert.Equal("Address1", orderModel.Address);
            Assert.Equal("123456789", orderModel.NumberPhone);
            Assert.Equal(PaymentMethod.COD, orderModel.method);
            Assert.Equal(OrderStatus.OrderPlaced, orderModel.status);
            Assert.Equal(100, orderModel.TotalAmount);
            Assert.Equal("Note1", orderModel.Note);

            var productOrder = orderModel.products.First();
            Assert.Equal("1", productOrder.ProductId);
            Assert.Equal("Product1", productOrder.ProductName);
            Assert.Equal(50, productOrder.UnitPrice);
            Assert.Equal(2, productOrder.Quantity);
            Assert.Equal("Image1.jpg", productOrder.ImageURL);
        }
    }
}

using EcommerceWeb.Application.Carts.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.XUnitTest.Carts
{
    public class CartModelTests
    {
        [Fact]
        public void CartModel_Should_Set_UserId_Correctly()
        {
            // Arrange
            var cart = new CartModel();
            var userId = "user123";

            // Act
            cart.UserId = userId;

            // Assert
            Assert.Equal(userId, cart.UserId);
        }

        [Fact]
        public void CartModel_Should_Set_ProductId_Correctly()
        {
            // Arrange
            var cart = new CartModel();
            var productId = "product456";

            // Act
            cart.ProductId = productId;

            // Assert
            Assert.Equal(productId, cart.ProductId);
        }

        [Fact]
        public void CartModel_Should_Set_Quantity_Correctly()
        {
            // Arrange
            var cart = new CartModel();
            var quantity = 10;

            // Act
            cart.Quantity = quantity;

            // Assert
            Assert.Equal(quantity, cart.Quantity);
        }

        [Fact]
        public void CartModel_Should_Have_Default_Values()
        {
            // Arrange & Act
            var cart = new CartModel();

            // Assert
            Assert.Null(cart.UserId);
            Assert.Null(cart.ProductId);
            Assert.Equal(0, cart.Quantity);
        }
    }
}

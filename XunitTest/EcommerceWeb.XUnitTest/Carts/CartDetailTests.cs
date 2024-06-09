using EcommerceWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.XUnitTest.Carts
{
    public class CartDetailTests
    {
        [Fact]
        public void CartDetail_Should_Have_Default_Values()
        {
            // Arrange
            var cartDetail = new CartDetail();

            // Assert
            Assert.Equal(0, cartDetail.Quantity);
            Assert.Null(cartDetail.ProductId);
            Assert.Null(cartDetail.Product);
            Assert.Null(cartDetail.Cart);
            Assert.Null(cartDetail.CartId);
        }

        [Fact]
        public void CartDetail_Should_Set_Values_Correctly()
        {
            // Arrange
            var cartDetail = new CartDetail
            {
                Quantity = 2,
                ProductId = "prod123",
                CartId = "cart456"
            };

            // Act
            var product = new Product { Id = "prod123", Name = "Product 1" };
            var cart = new Cart { Id = "cart456", UserId = "user789" };

            cartDetail.Product = product;
            cartDetail.Cart = cart;

            // Assert
            Assert.Equal(2, cartDetail.Quantity);
            Assert.Equal("prod123", cartDetail.ProductId);
            Assert.Equal("cart456", cartDetail.CartId);
            Assert.NotNull(cartDetail.Product);
            Assert.Equal("Product 1", cartDetail.Product.Name);
            Assert.NotNull(cartDetail.Cart);
            Assert.Equal("user789", cartDetail.Cart.UserId);
        }
    }
}

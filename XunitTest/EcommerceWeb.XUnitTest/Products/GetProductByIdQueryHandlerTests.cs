using EcommerceWeb.Application.Products.Common.Interfaces;
using EcommerceWeb.Application.Products.GetById;
using EcommerceWeb.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductImage = EcommerceWeb.Domain.Entities.Image;

namespace EcommerceWeb.XUnitTest.Products
{
    public class GetProductByIdQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ValidId_ReturnsProductModelAppLayer()
        {
            // Arrange
            var productId = "product123";
            var query = new GetProductByIdQuery(productId);
            var product = new Product
            {
                Id = productId,
                Name = "Test Product",
                UnitPrice = 9.99m,
                Inventory = 100,
                CategoryId = "category123",
                Description = "Test Description",
                Images = new List<ProductImage>()
            };

            var productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(repo => repo.GetProdcutByIdAsync(productId))
                                 .ReturnsAsync(product);

            var handler = new GetProductByIdQueryHandler(productRepositoryMock.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(productId, result.Id);
            Assert.Equal(product.Name, result.Name);
            Assert.Equal(product.UnitPrice, result.Price);
            Assert.Equal(product.Inventory, result.Stock);
            Assert.Equal(product.CategoryId, result.CategoryId);
            Assert.Equal(product.Description, result.Description);
            Assert.Equal(product.Images.Select(u => u.Url), result.Images);
            Assert.NotNull(result.Category);
            Assert.Equal(product.CategoryId, result.Category.Id);
            Assert.Equal(product.Name, result.Category.Name);
            Assert.Equal(product.Description, result.Category.Description);
        }

        [Fact]
        public async Task Handle_InvalidId_ThrowsException()
        {
            // Arrange
            var invalidProductId = "invalidProductId";
            var query = new GetProductByIdQuery(invalidProductId);

            var productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(repo => repo.GetProdcutByIdAsync(invalidProductId))
                                 .ReturnsAsync((Product)null);

            var handler = new GetProductByIdQueryHandler(productRepositoryMock.Object);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => handler.Handle(query, CancellationToken.None));
        }

        private IFormFileCollection GetMockIFormFileCollection()
        {
            var fileMock = new Mock<IFormFile>();
            var content = "Hello World from a Fake File";
            var fileName = "test.png";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMock.Setup(f => f.OpenReadStream()).Returns(ms);
            fileMock.Setup(f => f.FileName).Returns(fileName);
            fileMock.Setup(f => f.Length).Returns(ms.Length);

            var formFileCollection = new FormFileCollection { fileMock.Object };

            return formFileCollection;
        }
    }
}

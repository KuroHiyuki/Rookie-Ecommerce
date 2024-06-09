using EcommerceWeb.Application.Products.Common.Interfaces;
using EcommerceWeb.Application.Products.GetByName;
using EcommerceWeb.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.XUnitTest.Products
{
    public class GetProductByNameQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsCorrectProducts()
        {
            // Arrange
            var categoryName = "Electronics";
            var query = new GetProductByNameQuery(categoryName);

            var products = new List<Product>
        {
            new Product { Id = "1", Name = "Laptop", Description = "High-performance laptop", UnitPrice = 999.99m, Inventory = 10, Category = new Category { Id = "1", Name = "Electronics" } },
            new Product { Id = "2", Name = "Smartphone", Description = "Latest smartphone model", UnitPrice = 699.99m, Inventory = 20, Category = new Category { Id = "1", Name = "Electronics" } }
        };

            var productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(repo => repo.GetListAsync(It.IsAny<Expression<Func<Product, bool>>>(), It.IsAny<CancellationToken>()))
                      .ReturnsAsync(products);

            var handler = new GetProductByNameQueryHandler(productRepositoryMock.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            var resultList = result.ToList();
            Assert.Equal(2, resultList.Count);

            var firstProduct = resultList[0];
            Assert.Equal("1", firstProduct.Id);
            Assert.Equal("Laptop", firstProduct.Name);
            Assert.Equal("High-performance laptop", firstProduct.Description);
            Assert.Equal(999.99m, firstProduct.Price);
            Assert.Equal(10, firstProduct.Stock);
            Assert.Equal("Electronics", firstProduct.Category.Name);

            var secondProduct = resultList[1];
            Assert.Equal("2", secondProduct.Id);
            Assert.Equal("Smartphone", secondProduct.Name);
            Assert.Equal("Latest smartphone model", secondProduct.Description);
            Assert.Equal(699.99m, secondProduct.Price);
            Assert.Equal(20, secondProduct.Stock);
            Assert.Equal("Electronics", secondProduct.Category.Name);
        }
    }
}

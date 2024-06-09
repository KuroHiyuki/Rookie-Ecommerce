using EcommerceWeb.Application.Categories.Common.Repository;
using EcommerceWeb.Application.Categories.GetAllCategory;
using EcommerceWeb.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.XUnitTest.Categories
{
    public class GetCategoryListQueryHandlerTests
    {
        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;
        private readonly GetCategoryListQueryHandler _handler;

        public GetCategoryListQueryHandlerTests()
        {
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _handler = new GetCategoryListQueryHandler(_categoryRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnCategoryList_WhenCategoryExists()
        {
            // Arrange
            var categories = new List<Category>
            {
                new Category { Id = "1", Name = "Category 1", Description = "Description 1" },
                new Category { Id = "2", Name = "Category 2", Description = "Description 2" }
            };

            _categoryRepositoryMock.Setup(repo => repo.GetListAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<CancellationToken>()))
                        .ReturnsAsync(categories);

            var query = new GetCategoryListQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());

            var categoryModel = result.First();
            Assert.Equal("1", categoryModel.Id);
            Assert.Equal("Category 1", categoryModel.Name);
            Assert.Equal("Description 1", categoryModel.Description);
        }
    }
}

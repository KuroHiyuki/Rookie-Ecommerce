using EcommerceWeb.Application.Categories.Common.Repository;
using EcommerceWeb.Application.Categories.UpdateCategory;
using EcommerceWeb.Application.Common.Interface;
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
    public class UpdateCategoryByIdCommandHandlerTests
    {
        private readonly UpdateCategoryByIdCommandHandler _handler;
        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public UpdateCategoryByIdCommandHandlerTests()
        {
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _handler = new UpdateCategoryByIdCommandHandler(_categoryRepositoryMock.Object, _unitOfWorkMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldUpdateCategory_WhenCategoryExists()
        {
            // Arrange
            var categoryId = "1";
            var command = new UpdateCategoryByIdCommand(categoryId, "Updated Category Name", "Updated Category Description");

            var existingCategory = new Category
            {
                Id = categoryId,
                Name = "Original Category Name",
                Description = "Original Category Description"
            };

            _categoryRepositoryMock.Setup(repo => repo.GetByIdAsync(categoryId, CancellationToken.None))
                .ReturnsAsync(existingCategory);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _categoryRepositoryMock.Verify(repo => repo.Update(It.IsAny<Category>()), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.SaveAsync(It.IsAny<CancellationToken>()), Times.Once);
            Assert.Equal(command.Name, existingCategory.Name);
            Assert.Equal(command.Description, existingCategory.Description);
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenCategoryDoesNotExist()
        {
            // Arrange
            var categoryId = "1";
            var command = new UpdateCategoryByIdCommand(categoryId, "Updated Category Name", "Updated Category Description");

            _categoryRepositoryMock.Setup(repo => repo.GetListAsync(It.IsAny<Expression<Func<Category, bool>>>(), CancellationToken.None));

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}

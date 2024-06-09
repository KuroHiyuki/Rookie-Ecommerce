using EcommerceWeb.Application.Categories.Common.Repository;
using EcommerceWeb.Application.Categories.DeleteCategory;
using EcommerceWeb.Application.Common.Errors;
using EcommerceWeb.Application.Common.Interface;
using EcommerceWeb.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.XUnitTest.Categories
{
    public class DeleteCategoryCommandHandlerTests
    {
        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly DeleteCategoryCommandHandler _handler;

        public DeleteCategoryCommandHandlerTests()
        {
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _handler = new DeleteCategoryCommandHandler(_unitOfWorkMock.Object, _categoryRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldDeleteCategory_WhenCategoryExists()
        {
            // Arrange
            var categoryId = "123";
            var command = new DeleteCategoryCommand(categoryId);
            var category = new Category { Id = categoryId, Name = "TestCategory" };

            _categoryRepositoryMock.Setup(repo => repo.GetByIdAsync(categoryId, CancellationToken.None))
                                   .ReturnsAsync(category);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _categoryRepositoryMock.Verify(repo => repo.Delete(category), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.SaveAsync(CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldThrowNotFoundException_WhenCategoryDoesNotExist()
        {
            // Arrange
            var categoryId = "123";
            var command = new DeleteCategoryCommand(categoryId);

            _categoryRepositoryMock.Setup(repo => repo.GetByIdAsync(categoryId, CancellationToken.None))
                                   .ReturnsAsync((Category)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
            _categoryRepositoryMock.Verify(repo => repo.Delete(It.IsAny<Category>()), Times.Never);
            _unitOfWorkMock.Verify(uow => uow.SaveAsync(CancellationToken.None), Times.Never);
        }
    }
}

using EcommerceWeb.Application.Categories.Common.Repository;
using EcommerceWeb.Application.Categories.Common.Response;
using EcommerceWeb.Application.Categories.CreateCategory;
using EcommerceWeb.Application.Common.Interface;
using EcommerceWeb.Application.Common.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.XUnitTest.Categories
{
    public class CreateCategoryCommandHandlerTests
    {
        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IFileStorage> _fileStorageServiceMock;
        private readonly CreateCategoryCommandHandler _handler;

        public CreateCategoryCommandHandlerTests()
        {
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _fileStorageServiceMock = new Mock<IFileStorage>();
            _handler = new CreateCategoryCommandHandler(_unitOfWorkMock.Object, _fileStorageServiceMock.Object, _categoryRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldCreateCategoryAndSaveToDatabase()
        {
            // Arrange
            var command = new CreateCategoryCommand("TestCategory", "TestDescription");

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _categoryRepositoryMock.Verify(repo => repo.CreateCateogryAsync(It.IsAny<CategoryModelAppLayer>()), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.SaveAsync(CancellationToken.None), Times.Once);
        }
    }
}

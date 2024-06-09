using EcommerceWeb.Application.Common.Errors;
using EcommerceWeb.Application.Common.Interface;
using EcommerceWeb.Application.Products.Common.Interfaces;
using EcommerceWeb.Application.Products.UpdateProduct;
using EcommerceWeb.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Moq;
using ProductImage = EcommerceWeb.Domain.Entities.Image;

namespace EcommerceWeb.XUnitTest.Products
{
    public class UpdateProductCommandHandlerTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly UpdateProductCommandHandler _handler;

        public UpdateProductCommandHandlerTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _handler = new UpdateProductCommandHandler(_unitOfWorkMock.Object, _productRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldThrowNotFoundException_WhenProductDoesNotExist()
        {
            // Arrange
            var command = new UpdateProductCommand("123", "Test Product", "Test Description", 100, 10, "test-category", null);

            _productRepositoryMock
                .Setup(repo => repo.GetByIdAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Product)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }


        [Fact]
        public async Task Handle_ShouldUpdateProductAndSaveImages_WhenProductExists()
        {
            // Arrange
            var existingProduct = new Product
            {
                Id = "existing-id",
                Name = "Old Name",
                Description = "Old Description",
                UnitPrice = 50,
                Inventory = 5,
                Images = new List<ProductImage>() // Sử dụng alias để tránh xung đột tên
            };

            var command = new UpdateProductCommand("existing-id", "New Name", "New Description", 100, 10, "test-category", GetMockIFormFileCollection());

            _productRepositoryMock
                .Setup(repo => repo.GetByIdAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingProduct);

            _productRepositoryMock
                .Setup(repo => repo.SaveProductImagesAsync(It.IsAny<IFormFileCollection>(), It.IsAny<string>()))
                .ReturnsAsync(new List<ProductImage> { new ProductImage { Url = "new-image-url" } });

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _productRepositoryMock.Verify(repo => repo.RemoveProductImagesAsync(existingProduct), Times.Once);
            _productRepositoryMock.Verify(repo => repo.UpdateAsync(It.Is<Product>(p =>
                p.Name == command.Name &&
                p.Description == command.Description &&
                p.UnitPrice == command.UnitPrice &&
                p.Inventory == command.Inventorry &&
                p.Images.Count == 1 &&
                p.Images.First().Url == "new-image-url")), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.SaveAsync(It.IsAny<CancellationToken>()), Times.Once);
        }


        [Fact]
        public async Task Handle_ShouldUpdateProductWithoutImages_WhenNoImagesProvided()
        {
            // Arrange
            var existingProduct = new Product
            {
                Id = "existing-id",
                Name = "Old Name",
                Description = "Old Description",
                UnitPrice = 50,
                Inventory = 5,
                Images = new List<Image>()
            };

            var command = new UpdateProductCommand("existing-id", "New Name", "New Description", 100, 10, "test-category", null);

            _productRepositoryMock
                .Setup(repo => repo.GetByIdAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingProduct);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            
            _productRepositoryMock.Verify(repo => repo.UpdateAsync(It.Is<Product>(p =>
                p.Name == command.Name &&
                p.Description == command.Description &&
                p.UnitPrice == command.UnitPrice &&
                p.Inventory == command.Inventorry &&
                p.Images.Count == 0)), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.SaveAsync(It.IsAny<CancellationToken>()), Times.Once);
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

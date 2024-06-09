using EcommerceWeb.Application.Common.Interface;
using EcommerceWeb.Application.Products.Common.Interfaces;
using EcommerceWeb.Application.Products.Common.Response;
using EcommerceWeb.Application.Products.CreateProduct;
using EcommerceWeb.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.XUnitTest.Products
{
    public class CreateProductCommandHandlerTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly CreateProductCommandHandler _handler;

        public CreateProductCommandHandlerTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _handler = new CreateProductCommandHandler(_productRepositoryMock.Object, _unitOfWorkMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldCreateProductAndSaveImages_WhenImagesAreProvided()
        {
            // Arrange
            var command = new CreateProductCommand
            {
                Name = "Test Product",
                Description = "Test Description",
                Price = 100,
                Stock = 10,
                CategoryId = "test-category",
                Images = GetMockIFormFileCollection()
            };

            _productRepositoryMock
                .Setup(repo => repo.SaveProductImagesAsync(It.IsAny<IFormFileCollection>(), It.IsAny<string>()))
                .ReturnsAsync(new List<Image> { new Image { Url = "new-image-url" } });

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _productRepositoryMock.Verify(repo => repo.SaveProductImagesAsync(It.IsAny<IFormFileCollection>(), It.IsAny<string>()), Times.Once);
            _productRepositoryMock.Verify(repo => repo.CreateProductAsync(It.IsAny<ProductModelAppLayer>(), It.IsAny<List<Image>>()), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.SaveAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldCreateProductWithoutImages_WhenNoImagesProvided()
        {
            // Arrange
            var command = new CreateProductCommand
            {
                Name = "Test Product",
                Description = "Test Description",
                Price = 100,
                Stock = 10,
                CategoryId = "test-category",
                Images = null
            };

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _productRepositoryMock.Verify(repo => repo.SaveProductImagesAsync(It.IsAny<IFormFileCollection>(), It.IsAny<string>()), Times.Never);
            _productRepositoryMock.Verify(repo => repo.CreateProductAsync(It.IsAny<ProductModelAppLayer>(), It.Is<List<Image>>(images => images.Count == 0)), Times.Once);
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

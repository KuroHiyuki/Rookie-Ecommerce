//using EcommerceWeb.Application.Categories.Common.Response;
//using EcommerceWeb.Application.Common.Services.Paginations;
//using EcommerceWeb.Application.Products.Common.Interfaces;
//using EcommerceWeb.Application.Products.Common.Response;
//using EcommerceWeb.Application.Products.GetbyCategory;
//using Moq;


//namespace EcommerceWeb.XUnitTest.Categories
//{
//    public class GetProductByCategoryQueryHandlerTests
//    {
//        [Fact]
//        public async Task Handle_Should_Return_Products_By_Category()
//        {
//            // Arrange
//            var category = new CategoryModelAppLayer
//            {
//                Id = "1",
//                Name = "Electronics",
//            };
//            var mockProductRepository = new Mock<IProductRepository>();
//            var sampleProducts = new List<ProductModelAppLayer>
//            {
//                new() { Id = "1", Name = "Product1" ,Category= category },
//                new() { Id = "2", Name = "Product2" ,Category= category }
//            };

//            var paginatedProducts = new Paginated<ProductModelAppLayer>(sampleProducts, 1, 10, sampleProducts.Count);

//            mockProductRepository.Setup(repo => repo.GetProductsByCategoryNameAsync(
//                It.IsAny<string>(),
//                It.IsAny<string>(),
//                It.IsAny<string>(),
//                It.IsAny<string>(),
//                It.IsAny<int>(),
//                It.IsAny<int>(),
//                It.IsAny<CancellationToken>()))
//                .ReturnsAsync(paginatedProducts);

//            var handler = new GetProductByCategoryQueryHandler(mockProductRepository.Object);

//            var query = new GetProductByCategoryQuery("Electronics", new PageQuery( 1, 10 ));

//            // Act
//            var result = await handler.Handle(query, CancellationToken.None);

//            // Assert
//            Assert.NotNull(result);
//            Assert.Equal(2, result.Items.Count());
//            Assert.Equal("1", result.Items.First().Id);
//            Assert.Equal("2", result.Items.Last().Id);
//        }
//    }
//}

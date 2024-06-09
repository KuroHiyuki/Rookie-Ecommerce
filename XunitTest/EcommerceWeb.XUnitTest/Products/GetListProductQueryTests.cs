using EcommerceWeb.Application.Common.Services.Paginations;
using EcommerceWeb.Application.Products.GetListProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.XUnitTest.Products
{
    public class GetListProductQueryTests
    {
        [Fact]
        public void GetListProductQuery_Should_Set_PageQuery_Correctly()
        {
            // Arrange
            PageQuery pageQuery = new PageQuery
            {
                Page = 1,
                PageSize = 10,
            };

            // Act
            var query = new GetListProductQuery(pageQuery);

            // Assert
            Assert.Equal(pageQuery, query.page);
        }
    }

}

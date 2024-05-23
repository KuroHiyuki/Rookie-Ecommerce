using EcommerceWeb.Application.Products.Common.Response;
using EcommerceWeb.Application.Products.CreateProduct;
using EcommerceWeb.Application.Products.UpdateProduct;
using EcommerceWeb.Presentation.Products;
using Mapster;

namespace EcommerceWeb.WebApi.Common.Mapping
{
    public class ProductMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //config.NewConfig<ProductRequest, ProductQuery>();
            config.NewConfig<ProductModels, ProductModelAppLayer>();
            //config.NewConfig<CreateProductCommand, ProductRequest>();


            config.NewConfig<UpdateProductCommand, UpdateProductRequest>();
            //config.NewConfig<ProductRequest, ProductModelAppLayer>();
        }
    }
}

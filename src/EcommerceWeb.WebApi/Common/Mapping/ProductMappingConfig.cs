using EcommerceWeb.Application.Authentication.Commands.Register;
using EcommerceWeb.Application.Products.Query;
using EcommerceWeb.Presentation.Products;
using Mapster;

namespace EcommerceWeb.WebApi.Common.Mapping
{
    public class ProductMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ProductRequest, ProductQuery>();
        }
    }
}

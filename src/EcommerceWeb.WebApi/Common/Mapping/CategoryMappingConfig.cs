using EcommerceWeb.Application.Categories.Common.Response;
using EcommerceWeb.Presentation.Categories;
using Mapster;

namespace EcommerceWeb.WebApi.Common.Mapping
{
    public class CategoryMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CategoryModel, CategoryModelAppLayer>();
        }
    }
}

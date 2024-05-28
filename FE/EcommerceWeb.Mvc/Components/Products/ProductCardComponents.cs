using EcommerceWeb.Mvc.Models.Products;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.Mvc.Components.Products
{
    [ViewComponent(Name = "ProductCard")]
    public class ProductCardComponents : ViewComponent
    {
        public IViewComponentResult Invoke(ProductVM product)
        {
            return View(product);
        }
    }
}

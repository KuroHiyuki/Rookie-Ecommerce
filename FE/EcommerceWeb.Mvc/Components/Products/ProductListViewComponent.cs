using EcommerceWeb.Mvc.Models.Products;
using EcommerceWeb.Mvc.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.Mvc.Components.Products
{
    public class ProductListViewComponent : ViewComponent
    {
		private readonly IProductServices _productService;

		public ProductListViewComponent(IProductServices productService)
		{
			_productService = productService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
			var products = await _productService.GetProductsAsync();


			if (products is null)
			{
				return View("NoProducts");
			}

			return View(products);
		}
    }
}

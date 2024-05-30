using EcommerceWeb.Mvc.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.Mvc.Components.Categories
{
	public class CategoryMenuViewComponent
	{
		private readonly IProductServices _productService;
		public CategoryMenuViewComponent(IProductServices productService)
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

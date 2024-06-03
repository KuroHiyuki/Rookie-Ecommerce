using EcommerceWeb.Mvc.Services.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcommerceWeb.Mvc.Components.Common
{
	public class QuickViewComponent :ViewComponent
	{
		private readonly IProductServices _productServices;

		public QuickViewComponent(IProductServices productServices)
		{
			_productServices = productServices;
		}
		public async Task<IViewComponentResult> InvokeAsync(string productId)
		{
			if (!string.IsNullOrEmpty(productId))
			{
				var products = await _productServices.GetProductByIdAsync(productId);

				if (products is null)
				{
					return View("NoProducts");
				}
				return View(products);
			}
			return View("Error");
		}

	}
}

using EcommerceWeb.Mvc.Models.Products;
using EcommerceWeb.Mvc.Services.Products;
using EcommerceWeb.Presentation.Common;
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

		public async Task<IViewComponentResult> InvokeAsync(string categoryName = default!, PageQuery page = default!,string filter = default!)
        {
            switch (filter)
            {
                case "LowtoHigh":
                    page.SortColumn = "4";
                    page.SortOrder = "desc";
                    break;

                case "HightoLow":
                    page.SortColumn = "4";
                    page.SortOrder = "asc";
                    break;
                case "Newest": 
                    page.SortColumn = "5";
                    page.SortOrder = "asc";
                    break;
                default:
                    break;
            }

            if (!string.IsNullOrEmpty(categoryName))
			{
                var products = await _productService.GetProductsByCategoryNameAsync(categoryName, page);

                if (products is null)
                {
                    return View("NoProducts");
                }

                return View(products);
            }
			else
			{
                var products = await _productService.GetProductsAsync(page);

                if (products is null)
                {
                    return View("NoProducts");
                }

                return View(products);
            }			
		}
	}
}

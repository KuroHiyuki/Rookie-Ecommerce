using EcommerceWeb.Mvc.Services.Categories;
using EcommerceWeb.Mvc.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.Mvc.Components.Categories
{
	public class CategoryMenuViewComponent : ViewComponent
	{
		private readonly ICategoryServices _categoryServices;

		public CategoryMenuViewComponent(ICategoryServices categoryServices)
		{
			_categoryServices = categoryServices;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{

			var category = await _categoryServices.GetListAsync();

			if (category is null)
			{
				return View("NoProducts");
			}

			return View(category);
		}
	}
}

using EcommerceWeb.Mvc.Services.Carts;
using EcommerceWeb.Mvc.Services.Categories;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.Mvc.Components.Carts
{
	public class QuickCartViewComponent:ViewComponent
	{
		private readonly ICartServices _cartServices;

		public QuickCartViewComponent(ICartServices cartServices)
		{
			_cartServices = cartServices;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}

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
			string userId = Request.Cookies["UserId"]!;
			if (ModelState.IsValid)
			{
				var cartId = await _cartServices.GetCardIdAsync(userId);
				if (cartId == null)
				{
					if (TempData.ContainsKey("ErrorMessage"))
					{
						ViewBag.ErrorMessage = TempData[cartId!];
					}
				}
				var response = await _cartServices.GetProductInCartAsynce(cartId, userId);
				return View(response);
			}
			return View("Error");
		}
	}
}

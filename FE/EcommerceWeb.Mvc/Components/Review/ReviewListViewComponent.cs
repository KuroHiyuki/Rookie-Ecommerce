using EcommerceWeb.Mvc.Services.Reviews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcommerceWeb.Mvc.Components.Review
{
    public class ReviewListViewComponent : ViewComponent
    {
        private readonly IReviewServices _reviewServices;

        public ReviewListViewComponent(IReviewServices reviewServices)
        {
            _reviewServices = reviewServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(string ProdcutId)
        {
            var reviews = await _reviewServices.GetReviewListAsync(ProdcutId);

            if (reviews is null)
            {
                return View("NoComment");
            }

            return View(reviews);
        }
    }
}

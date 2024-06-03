using EcommerceWeb.Mvc.Models.Reviews;
using EcommerceWeb.Mvc.Services.Reviews;
using EcommerceWeb.Presentation.Reviews;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace EcommerceWeb.Mvc.Controllers
{

    public class ReviewController : Controller
    {
        private readonly IReviewServices _reviewServices;

        public ReviewController(IReviewServices reviewServices)
        {
            _reviewServices = reviewServices;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(string ProductId, ReviewRequest request)
        {
            if (ModelState.IsValid)
            {
                bool success = await _reviewServices.CreateReviewProductAsync(ProductId, request);
                return RedirectToAction("Details", "Product", new { id = ProductId });
            }
            return View("Error");
        }
        [HttpPost("delete")]
        public async Task<IActionResult> Delete(string ProductId, string reviewId, [FromForm(Name = "_method")] string method)
        {
            if (method == "DELETE")
            {
                await _reviewServices.RemoveReviewAsync(ProductId,reviewId);
                return RedirectToAction("Details", "Product", new { id = ProductId });

            }
            return View("Error");
        }
        [HttpPost("Edit")]
        public async Task<IActionResult> Update(string ProductId, string reviewId, [FromForm(Name = "_method")] string method, ReviewRequest request)
        {
            if (method == "PUT")
            {
                await _reviewServices.UpdateReviewAsync(ProductId, reviewId,request);
                return RedirectToAction("Details", "Product", new { id = ProductId });

            }
            return View("Error");
        }

    }
}

using EcommerceWeb.Mvc.Services.Products;
using EcommerceWeb.Presentation.Common;
using EcommerceWeb.Presentation.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.Mvc.Controllers
{
    public class ProductController : Controller
    {
        [BindProperty]
        public AddToCartModel AddToCartInput { get; set; } = new AddToCartModel();
        private readonly ILogger<ProductController> _logger;
        private readonly IProductServices _productServices;
		private readonly IViewComponentHelper _viewComponentHelper;
		public ProductController(IProductServices productServices, ILogger<ProductController> logger, IViewComponentHelper viewComponentHelper)
		{
			_productServices = productServices;
			_logger = logger;
			_viewComponentHelper = viewComponentHelper;
		}

		[AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            await Task.CompletedTask;
            return View();
        }
		
		[AllowAnonymous]
		public async Task<IActionResult> Details(string id)
        {
            _logger.LogInformation("Get product by id from API");
            var product = await _productServices.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> AddToCart(string id)
        {
            _logger.LogInformation("Add product to cart");
            var product = await _productServices.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Redirect("/cart");
        }
		
	}
}

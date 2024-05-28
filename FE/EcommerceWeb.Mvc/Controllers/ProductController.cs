using EcommerceWeb.Mvc.Services.Products;
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
		public string Test = "a45bcfdc-187a-4cda-ab3e-9cad3492fa6c";
		public ProductController(IProductServices productServices, ILogger<ProductController> logger)
        {
            _productServices = productServices;
            _logger = logger;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Get products from API");
            var products = await _productServices.GetProductsAsync();
            return View(products);
        }

        [AllowAnonymous]
       

		public async Task<IActionResult> Details(string id)
        {
            _logger.LogInformation("Get product by id from API");
            var product = await _productServices.GetProductByIdAsync(Test);
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

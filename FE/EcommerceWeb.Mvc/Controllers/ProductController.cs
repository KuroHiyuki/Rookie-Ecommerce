using EcommerceWeb.Mvc.Services.Products;
using EcommerceWeb.Presentation.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.Mvc.Controllers
{
    [Route("products")]
    public class ProductController : Controller
    {
        [BindProperty]
        public AddToCartModel AddToCartInput { get; set; } = new AddToCartModel();
        private readonly ILogger<ProductController> _logger;
        private readonly IProductServices _productServices;

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
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
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
        public async Task<IActionResult> AddToCart(int id)
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

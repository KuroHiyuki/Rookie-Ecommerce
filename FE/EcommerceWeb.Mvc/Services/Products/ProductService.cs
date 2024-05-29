using EcommerceWeb.Mvc.Models.Products;
using EcommerceWeb.Presentation.Common;
using Newtonsoft.Json;
using System.Text.Json;

namespace EcommerceWeb.Mvc.Services.Products
{
    public class ProductService : IProductServices
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7273");
        }

        public async Task<ProductVM?> GetProductByIdAsync(string id)
        {
            var response = await _httpClient.GetAsync($"/product/{id}");

            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductVM?>(content);
            return product;
        }

        public async Task<Paginated<ProductVM>> GetProductsAsync()
        {
            var response = await _httpClient.GetAsync("/product");

            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
			var products = JsonConvert.DeserializeObject<Paginated<ProductVM>>(content)!;
			return products;
        }

        public async Task<Paginated<ProductVM>> GetProductsByCategoryNameAsync(string categoryName)
        {
            var response = await _httpClient.GetAsync($"api/v1/products/collections/{categoryName}");

            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<Paginated<ProductVM>>(content)!;
            return products;
        }
    }
}

using EcommerceWeb.Mvc.Models.Products;
using Newtonsoft.Json;

namespace EcommerceWeb.Mvc.Services.Products
{
    public class ProductService : IProductServices
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7273/");
        }

        public async Task<ProductVM?> GetProductByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/v1/products/{id}");

            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductVM?>(content);
            return product;
        }

        public async Task<List<ProductVM>> GetProductsAsync()
        {
            var response = await _httpClient.GetAsync("api/v1/products");

            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ProductVM>>(content)!;
            return products;
        }

        public async Task<List<ProductVM>> GetProductsByCategoryNameAsync(string categoryName)
        {
            var response = await _httpClient.GetAsync($"api/v1/products/collections/{categoryName}");

            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ProductVM>>(content)!;
            return products;
        }
    }
}

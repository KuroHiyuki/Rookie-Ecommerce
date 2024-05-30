using EcommerceWeb.Mvc.Models.Products;
using EcommerceWeb.Presentation.Common;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

namespace EcommerceWeb.Mvc.Services.Products
{
    public class ProductService : IProductServices
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ProductVM?> GetProductByIdAsync(string id)
        {
            var response = await _httpClient.GetAsync($"/product/{id}");

            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductVM?>(content);
            return product;
        }

        public async Task<Paginated<ProductVM>> GetProductsAsync(PageQuery page = default!)
        {
			var url = "/product";
			if (page != null)
			{
				var queryString = new StringBuilder("?");
				if (page.Page is not 1 and > 0)
				{
					queryString.Append($"Page={page.Page}&");
				}

				queryString.Append("PageSize=1&");
                if (page.SearchTerm is not null)
                {
                    queryString.Append($"SearchTerm={page.SearchTerm}&");
                }
				// Xóa dấu & cuối cùng nếu có
				if (queryString[queryString.Length - 1] == '&')
				{
					queryString.Length -= 1;
				}
				url += queryString.ToString();
			}
			var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
			var products = JsonConvert.DeserializeObject<Paginated<ProductVM>>(content)!;
			return products;
        }

        public async Task<Paginated<ProductVM>> GetProductsByCategoryNameAsync(string categoryName, PageQuery page = default!)
        {
            var response = await _httpClient.GetAsync($"product/collections/{categoryName}");

            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<Paginated<ProductVM>>(content)!;
            return products;
        }
    }
}

using EcommerceWeb.Mvc.Models.Categories;
using Newtonsoft.Json;

namespace EcommerceWeb.Mvc.Services.Categories
{
	public class CategoryServices : ICategoryServices
	{
		private readonly HttpClient _httpClient;
		const string URL = "/category";
		public CategoryServices(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<List<CategoryVM>> GetListAsync()
		{
			var response = await _httpClient.GetAsync(URL);

			response.EnsureSuccessStatusCode();

			string content = await response.Content.ReadAsStringAsync();
			var categories = JsonConvert.DeserializeObject<List<CategoryVM>>(content)!;
			return categories;
		}
	}
}

using EcommerceWeb.Mvc.Models.Reviews;
using EcommerceWeb.Presentation.Common;
using EcommerceWeb.Presentation.Reviews;
using Newtonsoft.Json;
using System.Text;

namespace EcommerceWeb.Mvc.Services.Reviews
{
    public class ReviewServices : IReviewServices
    {
        private readonly HttpClient _httpClient;
        const string UserId = "12dec763-64c7-405c-b914-9f9d3d33e5fe";
        public ReviewServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateReviewProductAsync(string ProductId, ReviewRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync($"review/{UserId},{ProductId}", request);
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<ReviewVM>> GetReviewListAsync(string productId)
        {
            var response = await _httpClient.GetAsync($"review/{productId}");

            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            var reviews = JsonConvert.DeserializeObject<IEnumerable<ReviewVM>>(content)!;
            return reviews;
        }

        public async Task RemoveReviewAsync(string productId, string reviewId)
        {
            var response = await _httpClient.DeleteAsync($"review/{reviewId}");
            response.EnsureSuccessStatusCode();
        }
    }
}

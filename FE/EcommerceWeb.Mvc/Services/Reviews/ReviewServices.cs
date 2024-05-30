using EcommerceWeb.Mvc.Models.Reviews;
using EcommerceWeb.Presentation.Common;
using Newtonsoft.Json;

namespace EcommerceWeb.Mvc.Services.Reviews
{
    public class ReviewServices : IReviewServices
    {
        private readonly HttpClient _httpClient;

        public ReviewServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task CreateReviewProduct(string ProductId, string Comment, int Rating)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ReviewVM>> GetReviewListAsync(string productId)
        {
            var response = await _httpClient.GetAsync($"review/{productId}");

            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            var reviews = JsonConvert.DeserializeObject<IEnumerable<ReviewVM>>(content)!;
            return reviews;
        }

        public Task RemoveReviewAsync(string productId, string reviewId)
        {
            throw new NotImplementedException();
        }
    }
}

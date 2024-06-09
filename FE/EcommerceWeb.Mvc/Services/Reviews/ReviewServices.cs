using EcommerceWeb.Mvc.Models.Reviews;
using EcommerceWeb.Presentation.Common;
using EcommerceWeb.Presentation.Reviews;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;

namespace EcommerceWeb.Mvc.Services.Reviews
{
    public class ReviewServices : IReviewServices
    {
        private readonly HttpClient _httpClient;
        public ReviewServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateReviewProductAsync(string ProductId,string UserId, ReviewRequest request)
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

        public async Task<dynamic> RemoveReviewAsync(string UserId, string reviewId)
        {
            var response = await _httpClient.DeleteAsync($"review/{reviewId},{UserId}");
            
            return response;
		}

        public async Task<dynamic> UpdateReviewAsync(string UserId, string reviewId, ReviewRequest request)
        {
            var response = await _httpClient.PutAsJsonAsync($"review/{reviewId},{UserId}", request);
			
            return response;
		}
    }
}

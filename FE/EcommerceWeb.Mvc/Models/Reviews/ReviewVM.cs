namespace EcommerceWeb.Mvc.Models.Reviews
{
    public class ReviewVM
    {
        public string? Id { get; set; }
        public string? ProductId { get; set; }
        public int Rating { get; set; }
        public string? Commnet { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set; }
    }
}

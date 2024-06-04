namespace EcommerceWeb.Mvc.Models.Common
{
    public class ErrorResponse
    {
        public string? type { get; set; }
        public string? title { get; set; }
        public int status { get; set; }
        public string? traceId { get; set; }
        public List<string>? errorCode { get; set; }
        public string? CustomLater {  get; set; }
    }
}

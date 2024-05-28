namespace EcommerceWeb.Mvc.Models.Common
{
    public class ErrorHandlerModel
    {
        public string? RequestId { get; set; }
        public bool ? ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}

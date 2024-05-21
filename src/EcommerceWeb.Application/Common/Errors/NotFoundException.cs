using FluentResults;

namespace EcommerceWeb.Application.Common.Errors
{
    public class NotFoundException : Exception
    {
        public List<IError> Errors { get; set; } = new();
        public NotFoundException(string message) : base(message)
        {

        }

        public NotFoundException(List<IError> errors) : base("Multiple errors occurred. See error details.")
        {
            Errors = errors;
        }
    }
}

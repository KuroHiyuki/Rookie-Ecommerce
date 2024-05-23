using MediatR;
using ErrorOr;

namespace EcommerceWeb.Application.Carts.AddProduct
{
    public record AddProductToCartCommand(string Id) : IRequest<ErrorOr<FluentResults.Result>>
    {
    }
}

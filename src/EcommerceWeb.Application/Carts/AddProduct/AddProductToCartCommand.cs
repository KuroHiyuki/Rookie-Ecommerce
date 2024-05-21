using MediatR;
using ErrorOr;

namespace EcommerceWeb.Application.Carts.AddProduct
{
    public record AddProductToCartCommand : IRequest<ErrorOr<FluentResults.Result>>
    {
    }
}

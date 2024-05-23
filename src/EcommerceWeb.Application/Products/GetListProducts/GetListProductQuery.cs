
using EcommerceWeb.Application.Common.Paginations;
using EcommerceWeb.Application.Products.Common.Response;
using FluentResults;
using MediatR;
namespace EcommerceWeb.Application.Products.GetAll
{
    public record GetAllProductQuery (
        PageQuery page) : IRequest<PaginatedList<ProductModelAppLayer>>
    {
    }
}

using EcommerceWeb.Application.Orders.Common.Repository;
using EcommerceWeb.Application.Orders.Common.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Orders.GetorderByUserId
{
    public class GetOrderIdQueryHandler : IRequestHandler<GetOrderIdQuery, OrderModelAppLayer>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderIdQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderModelAppLayer> Handle(GetOrderIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderByIdAsync(request.OrderId);
            var OrderModel = new OrderModelAppLayer
            {
                UserName = order.UserName,
                Address = order.Address,
                NumberPhone = order.TelephoneNumber,
                method = order.PaymentMethod,
                status = order.Status,
                TotalAmount = order.TotalAmount,
                Note = order.Note,
                products = order.Details.Select(x => new ProductOrder
                {
                    ProductId = x.ProductId,
                    ProductName = x.Product!.Name,
                    UnitPrice = x.UnitPrice,
                    Quantity = x.Quantity,
                    ImageURL = x.Product.ImageURL
                }).ToList()
            };
            return OrderModel;
        }
    }
}

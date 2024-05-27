using EcommerceWeb.Application.Orders.Common.Repository;
using EcommerceWeb.Application.Orders.Common.Response;
using MediatR;


namespace EcommerceWeb.Application.Orders.GetorderByUserId
{
    public class GetOrderListByUserQueryHandler : IRequestHandler<GetOrderListByUserQuery, List<OrderModelAppLayer>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderListByUserQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<OrderModelAppLayer>> Handle(GetOrderListByUserQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderByIdAsync(request.UserId);
            var orderDetail = order.Details.Select(c => new OrderModelAppLayer
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
            });
            var OrderModel = orderDetail.ToList();
            return OrderModel;
        }
    }
}

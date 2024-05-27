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
            var orderDetail = order.Select(c =>  new OrderModelAppLayer
            {
                UserName = c.UserName,
                Address = c.Address,
                NumberPhone = c.TelephoneNumber,
                method = c.PaymentMethod,
                status = c.Status,
                TotalAmount = c.TotalAmount,
                Note = c.Note,
                products = c.Details.Select(x => new ProductOrder
                {
                    ProductId = x.ProductId,
                    ProductName = x.Product!.Name,
                    UnitPrice = x.UnitPrice,
                    Quantity = x.Quantity,
                    ImageURL = x.Product.ImageURL
                }).ToList()
            }).ToList();
            
            return orderDetail;
        }
    }
}

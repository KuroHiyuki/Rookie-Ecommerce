using EcommerceWeb.Application.Orders.Common.Repository;
using EcommerceWeb.Domain.Entities;
using EcommerceWeb.Infrastructure.Common.BaseRepository;
using EcommerceWeb.Presentation.Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Infrastructure.Orders
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(EcommerceDbContext context) : base(context)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Domain.Common.Enum
{
    public enum OrderStatus
    {
        OrderPlaced = 0,
        InFulfillment = 1,
        OutForDelivery = 2,
        Delivered = 3,
        Cancelation = 4,
    }
}

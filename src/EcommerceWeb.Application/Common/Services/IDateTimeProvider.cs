using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Common.Services
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Presentation.Authutentication
{
    public record LoginRequest(
        string Email,
        string Password);
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Presentation.Authutentication
{
    public record RegisterRequest(
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string NumberPhone,
        string Address
    );
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Users.Common.Response
{
    public class UserUpdateModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AvatarURL { get; set; }
        public string? NumberPhone { get; set; }
        public string? Address { get; set; }
    }
}

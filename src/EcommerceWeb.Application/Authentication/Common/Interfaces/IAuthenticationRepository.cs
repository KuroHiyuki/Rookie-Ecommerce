using EcommerceWeb.Domain.Entities;

namespace EcommerceWeb.Application.Authentication.Common.Interfaces
{
    public interface IAuthenticationRepository
    {
        User GetByEmail(string email);
        void Add(User user);
    }
}

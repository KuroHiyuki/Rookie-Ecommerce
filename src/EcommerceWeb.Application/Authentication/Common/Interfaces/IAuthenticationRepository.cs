using EcommerceWeb.Domain.Entities;

namespace EcommerceWeb.Application.Authentication.Common.Interfaces
{
    public interface IAuthenticationRepository
    {
        Customer GetByEmail(string email);
        void Add(Customer user);
    }
}

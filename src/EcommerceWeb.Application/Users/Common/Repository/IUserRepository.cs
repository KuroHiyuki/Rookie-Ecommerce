using EcommerceWeb.Application.Users.Common.Response;
using EcommerceWeb.Domain.Entities;
using Microsoft.AspNetCore.Identity;
namespace EcommerceWeb.Application.Users.Common.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByIdAsync(string id);
        Task DeleteUserAsync(string UserId);
        Task<List<User>> GetUsersListAsync();
        Task UpdateUserAsync(string UserId, UserUpdateModel model);
    }
}

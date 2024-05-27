using EcommerceWeb.Application.Common.Interface;
using EcommerceWeb.Application.Products.Common.Interfaces;
using EcommerceWeb.Application.Users.Common.Repository;
using EcommerceWeb.Application.Users.Common.Response;
using EcommerceWeb.Domain.Entities;
using EcommerceWeb.Infrastructure.Common.BaseRepository;
using EcommerceWeb.Presentation.Persistences;
using FluentEmail.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EcommerceWeb.Infrastructure.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly EcommerceDbContext _dbcontext;

        public UserRepository(EcommerceDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task DeleteUserAsync(string UserId)
        {
            var user = await _dbcontext.Users.FindAsync(UserId);
            if (user is null)
            {
                throw new Exception($"Not found this User {UserId}");
            }

            _dbcontext.Users.Remove(user);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _dbcontext.Users.FirstOrDefaultAsync(x => x.Email == email);
            if(user is null)
            {
                throw new Exception($"Not found User email: {email}");
            }
            return user;
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            var user = await _dbcontext.Users!.FindAsync(id)!;
            if (user is null)
            {
                throw new Exception($"Not found User ID: {id}");
            }
            return user;
        }

        public async Task<List<User>> GetUsersListAsync()
        {
            return await _dbcontext.Users.ToListAsync();
        }

        public async Task UpdateUserAsync(string UserId, UserUpdateModel model)
        {
            var existingUser = await _dbcontext.Users.FindAsync(UserId);
            if (existingUser is null)
            {
                throw new Exception($"Not found User ID: {UserId}");
            }

            existingUser.FirstName = model.FirstName;
            existingUser.LastName = model.LastName;
            existingUser.Address = model.Address;
            existingUser.PhoneNumber = model.NumberPhone;
            existingUser.AvatarUrl = model.AvatarURL;


            await _dbcontext.SaveChangesAsync();
        }
    }
}

using EcommerceWeb.Application.Common.Interface;
using EcommerceWeb.Application.Products.Common.Interfaces;
using EcommerceWeb.Application.Users.Common.Repository;
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
    }
}

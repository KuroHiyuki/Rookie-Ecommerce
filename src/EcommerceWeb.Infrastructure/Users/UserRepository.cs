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
            return await _dbcontext.Users.FirstOrDefaultAsync(x => x.Email == email)!;
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            return await _dbcontext.Users!.FindAsync(id)!;
        }
    }
}

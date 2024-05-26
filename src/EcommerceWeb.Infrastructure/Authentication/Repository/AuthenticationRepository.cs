using EcommerceWeb.Application.Authentication.Common.Interfaces;
using EcommerceWeb.Domain.Entities;
using EcommerceWeb.Presentation.Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Infrastructure.Authentication.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly EcommerceDbContext _dbContext;

        public AuthenticationRepository(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(User user)
        {
            _dbContext.Add(user);

            _dbContext.SaveChanges();
        }

        public User GetByEmail(string email)
        {
            return _dbContext.Users
               .SingleOrDefault(u => u.Email == email)!;
        }
    }
}

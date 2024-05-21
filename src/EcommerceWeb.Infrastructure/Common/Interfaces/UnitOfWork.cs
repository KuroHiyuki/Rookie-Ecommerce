using EcommerceWeb.Application.Common.Interface;
using EcommerceWeb.Presentation.Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Infrastructure.Common.Interfaces
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EcommerceDbContext _dbContext;

        public UnitOfWork(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

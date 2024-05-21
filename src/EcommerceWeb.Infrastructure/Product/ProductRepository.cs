using EcommerceWeb.Application.Products.Common.Interfaces;
using EcommerceWeb.Infrastructure.Common.BaseRepository;
using EcommerceWeb.Presentation.Persistences;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EcommerceWeb.Infrastructure.Product
{
    public class ProductRepository : IProductRepository
    {
        public void Create(Domain.Entities.Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Domain.Entities.Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Product?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Domain.Entities.Product>> GetListAsync(Expression<Func<Domain.Entities.Product, bool>>? filter = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(Domain.Entities.Product product)
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.Entities.Product entity)
        {
            throw new NotImplementedException();
        }
    }
}

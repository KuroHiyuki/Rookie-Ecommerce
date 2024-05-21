using EcommerceWeb.Application.Common.Interface;
using EcommerceWeb.Domain.Entities.Base;
using EcommerceWeb.Presentation.Persistences;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Infrastructure.Common.BaseRepository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly EcommerceDbContext _dbContext;

        public BaseRepository(EcommerceDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public virtual void Create(T entity)
        {
            _dbContext.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _dbContext.Remove(entity);
        }

        public virtual async Task<T?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>().FindAsync(id, cancellationToken);
        }

        public virtual async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>>? filter, CancellationToken cancellationToken = default)
        {
            return filter != null
                ? await _dbContext.Set<T>().Where(filter).ToListAsync(cancellationToken)
                : await _dbContext.Set<T>().ToListAsync(cancellationToken);
        }

        public virtual void Update(T entity)
        {
            _dbContext.Update(entity);
        }
    }
}

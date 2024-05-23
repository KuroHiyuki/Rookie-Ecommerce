using EcommerceWeb.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Common.Interface
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T?> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken));
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>>? filter = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}

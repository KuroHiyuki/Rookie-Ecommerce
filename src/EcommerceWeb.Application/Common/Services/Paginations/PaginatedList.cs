using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Common.Services.Paginations
{
    public class Paginated<T>
    {
        public Paginated()
        {
        }

        private Paginated(IEnumerable<T> items, int page, int pageSize, int totalCount)
        {
            Items = items;
            Page = page;
            PageSize = pageSize;
            TotalCount = totalCount;
        }
        public IEnumerable<T> Items { get; } = new List<T>();
        public int Page { get; } = 1;
        public int PageSize { get; } = 10;
        public int TotalCount { get; } = 0;
        public bool HasNextPage => Page * PageSize < TotalCount;

        public bool HasPreviousPage => Page > 1;

        public static async Task<Paginated<T>> CreateAsync(IQueryable<T> query, int page, int pageSize)
        {
            var totalCount = await query.CountAsync();
            var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            return new(items, page, pageSize, totalCount);
        }
    }
}

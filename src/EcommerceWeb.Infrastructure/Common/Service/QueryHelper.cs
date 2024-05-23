using EcommerceWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Infrastructure.Common.Service
{
    public static class QueryHelper
    {
        public static IQueryable<Product> ApplyFiltersAndSorting(
        IQueryable<Product> query,
        string? searchTerm,
        string? sortOrder,
        string? sortColumn)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(p =>
                    p.Name!.Contains(searchTerm) || p.Description!.Contains(searchTerm));
            }

            if (sortOrder?.ToLower() == "desc")
            {
                query = query.OrderByDescending(GetSortProperty(sortColumn));
            }
            else
            {
                query = query.OrderBy(GetSortProperty(sortColumn));
            }

            return query;
        }

        private static Expression<Func<Product, object>> GetSortProperty(string? sortColumn) => sortColumn?.ToLower() switch
        {
            "name" => product => product.Name!,
            "description" => product => product.Description!,
            _ => product => product.Id!
        };
    }
}

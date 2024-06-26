﻿using EcommerceWeb.Application.Common.Services.Paginations;
using EcommerceWeb.Application.Products.Common.Interfaces;
using EcommerceWeb.Application.Products.Common.Response;
using EcommerceWeb.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EcommerceWeb.Application.Products.GetbyCategory
{
    public class GetProductByCategoryQueryHandler : IRequestHandler<GetProductByCategoryQuery, Paginated<ProductModelAppLayer>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByCategoryQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Paginated<ProductModelAppLayer>> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductsByCategoryNameAsync(
            query.CategoryName,
            query.Query.SearchTerm,
            query.Query.SortOrder,
            query.Query.SortColumn,
            query.Query.Page,
            query.Query.PageSize,
            cancellationToken);

            return products;
        }
    }
}

﻿using EcommerceWeb.Application.Categories.Common.Response;
using EcommerceWeb.Application.Common.Interface;
using EcommerceWeb.Application.Common.Paginations;
using EcommerceWeb.Application.Products.Common.Interfaces;
using EcommerceWeb.Application.Products.Common.Response;
using EcommerceWeb.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EcommerceWeb.Application.Products.GetAll
{
    public class GetListProductQueryHandler : IRequestHandler<GetAllProductQuery, PaginatedList<ProductModelAppLayer>>
    {
        private readonly IProductRepository _productRepository;
        public GetListProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<PaginatedList<ProductModelAppLayer>> Handle(GetAllProductQuery query, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetListProductPageAsync(query.page,cancellationToken);
            return products!;
        }
    }
}

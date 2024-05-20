using EcommerceWeb.Application.Authentication.Common.Interfaces;
using EcommerceWeb.Application.Authentication.Common.Response;
using EcommerceWeb.Application.Products.Common.Interfaces;
using EcommerceWeb.Application.Products.Common.Response;
using EcommerceWeb.Domain.Entities;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EcommerceWeb.Application.Products.Query
{
    public class ProductQueryHandler(
        IProductRepository _productRepository) :
    IRequestHandler<ProductQuery, ErrorOr<ProductResult>>
    {

        public async Task<ErrorOr<ProductResult>> Handle(ProductQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            //if (_productRepository.GetProductById(query.Id.ToString()) is not Product product)
            //{
            //    throw new Exception();
            //}
            //var product = _productRepository.GetProductById(query.Id.ToString());
            //if (product == null) 
            //{ 
            //    throw new Exception();
            //}
            //return new ProductResult(product);
            throw new NotImplementedException();
        }
    }
}

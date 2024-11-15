using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.ProductQuery;
using Application.Features.Results.ProductResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.ProductHandlers
{
    public class ResultProductsQueryHandler : IRequestHandler<ProductQuery, List<ProductQueryResult>>
    {
        private readonly IRepository<Product> _productRepository;

        public ResultProductsQueryHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductQueryResult>> Handle(ProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();
            
           

            return products.Select(product => new ProductQueryResult
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                Images = product.Images,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt,
                CategoryId = product.CategoryId,
                DolapURL = product.DolapURL,
                ShoppierURL = product.ShoppierURL
            }).ToList();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Application.Interfaces;
using Application.Features.Queries.ProductQuery;
using Application.Features.Results.ProductResults;
using Domain.Entities;

namespace Application.Features.Handlers.ProductHandlers
{
    public class ResultProductByIdQueryHandler : IRequestHandler<ProductQueryById, ProductQueryByIdResult>
    {
        private readonly IRepository<Product> _productRepository;

        public ResultProductByIdQueryHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductQueryByIdResult> Handle(ProductQueryById request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            
          

            return new ProductQueryByIdResult
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
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.ProductQuery;
using Application.Features.Results.ProductResults;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Handlers.ProductHandlers
{
    public class ResultProductNameQueryHandler : IRequestHandler<ProductByNameQuery, List<ProductFilterNameQueryResult>>
    {
        private readonly IProductRepository _productRepository;

        public ResultProductNameQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductFilterNameQueryResult>> Handle(ProductByNameQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.FilterByName(request.Name);
            return products.Select(p => new ProductFilterNameQueryResult
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Stock = p.Stock,
                Images = p.Images,
                DolapURL = p.DolapURL,
                ShoppierURL = p.ShoppierURL,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt,
                CategoryId = p.CategoryId,
                
                }).ToList();
        }
    }
}
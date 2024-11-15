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
    public class ResultProductCategoryQueryHandler : IRequestHandler<ProductByCategoryQuery, List<ProductFilterCategoryQueryResult>>
    {
        private readonly IProductRepository _productRepository;

        public ResultProductCategoryQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductFilterCategoryQueryResult>> Handle(ProductByCategoryQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.FilterByCategory(request.CategoryId);
            return products.Select(p => new ProductFilterCategoryQueryResult
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
                CategoryId = p.CategoryId
            }).ToList();
        }
    }
}
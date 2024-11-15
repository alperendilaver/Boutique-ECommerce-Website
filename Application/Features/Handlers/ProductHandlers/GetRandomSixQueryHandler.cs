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
    public class GetRandomSixQueryHandler : IRequestHandler<GetRandomSixProductsQuery, List<ProductQueryResult>>
    {
        private readonly IProductRepository _productRepository;
        public GetRandomSixQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<ProductQueryResult>> Handle(GetRandomSixProductsQuery request, CancellationToken cancellationToken)
        {
            var values = await _productRepository.GetRandomProducts();
            return values.Select(x => new ProductQueryResult{CategoryId = x.CategoryId,
            CreatedAt = x.CreatedAt,
            Description = x.Description,
            DolapURL = x.DolapURL,
            Id = x.Id,
            Images = x.Images,
            Name = x.Name,
            Price = x.Price,
            ShoppierURL = x.ShoppierURL,
            Stock = x.Stock,
            UpdatedAt = x.UpdatedAt}).ToList();
        }
    }
}
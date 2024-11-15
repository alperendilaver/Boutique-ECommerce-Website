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
    public class GetTotalProductQueryHandler:IRequestHandler<GetTotalProductsQuery,GetTotalProductsQueryResult>
    {
        private IProductRepository _productRepository;
        public GetTotalProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<GetTotalProductsQueryResult> Handle(GetTotalProductsQuery request, CancellationToken cancellationToken)
        {
            var cnt= await _productRepository.GetProductCount();
            return new GetTotalProductsQueryResult{Count = cnt};
        }
    }
}
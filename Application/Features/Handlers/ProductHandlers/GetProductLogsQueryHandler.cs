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
    public class GetProductLogsQueryHandler : IRequestHandler<GetProductLogsQueryById, List<GetProductLogsQueryByIdQueryResult>>
    {
        private readonly IProductRepository _productRepository;
        public GetProductLogsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<GetProductLogsQueryByIdQueryResult>> Handle(GetProductLogsQueryById request, CancellationToken cancellationToken)
        {
            var productLogs = await _productRepository.GetLogProduct(request.ProductId);
            return productLogs.Select(x=> new GetProductLogsQueryByIdQueryResult{
                DateCreated = x.DateCreated,
                ProductId = x.ProductId,
                IsDolap = x.IsDolap,
                LogId = x.LogId
            }).ToList();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.ProductQuery;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Handlers.ProductHandlers
{
    public class GetLogsCountQueryHandler : IRequestHandler<GetLogsCountQuery, int>
    {
        private readonly IProductRepository _productRepository;
        public GetLogsCountQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<int> Handle(GetLogsCountQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetLogsCount();
        }
    }
}
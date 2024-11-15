using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Handlers.ProductHandlers
{
    public class LogProductRouteCommandHandler : IRequestHandler<LogProductRouteCommand>
    {
        private readonly IProductRepository _productRepository;
        public LogProductRouteCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task Handle(LogProductRouteCommand request, CancellationToken cancellationToken)
        {
            await _productRepository.LogProduct(request.ProductId,request.IsDolap);
        }
    }
}
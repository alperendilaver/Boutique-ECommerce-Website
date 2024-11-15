using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Handlers.ProductHandlers
{
    public class RemoveFavoriteProductCommandHandler : IRequestHandler<RemoveFavoriteProduct>
    {
        private readonly IProductRepository _productRepository;
        public RemoveFavoriteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task Handle(RemoveFavoriteProduct request, CancellationToken cancellationToken)
        {
            await _productRepository.RemoveFavorites(request.UserId, request.ProductId);
        }
    }
}
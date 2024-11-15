using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Handlers.ProductHandlers
{
    public class AddFavoriteProductCommandHandler : IRequestHandler<AddFavoriteProductCommand>
    {
        private readonly IProductRepository _productRepository;
        public AddFavoriteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task Handle(AddFavoriteProductCommand request, CancellationToken cancellationToken)
        {
            await _productRepository.AddFavorites(request.UserId, request.ProductId);
        }
    }
}
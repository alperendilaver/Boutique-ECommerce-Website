using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.ProductHandlers
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand>
    {
        private readonly IRepository<Product> _productRepository;

        public RemoveProductCommandHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

      

        async Task IRequestHandler<RemoveProductCommand>.Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            
            if (product == null)
            {
                throw new Exception("Ürün bulunamadı.");
            }

            await _productRepository.RemoveAsync(product);
        }
    }
}
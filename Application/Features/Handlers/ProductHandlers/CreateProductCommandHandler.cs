using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Application.Interfaces;
using Domain.Entities;
using Application.Features.Commands;

namespace Application.Features.Handlers.ProductHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IRepository<Product> _productRepository;

        public CreateProductCommandHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

    
        async Task IRequestHandler<CreateProductCommand>.Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Stock = request.Stock,
                Images = request.Images,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CategoryId = request.CategoryId,
                DolapURL = request.DolapURL,
                ShoppierURL = request.ShoppierURL
            };

            await _productRepository.CreateAsync(product);
        }
    }
}
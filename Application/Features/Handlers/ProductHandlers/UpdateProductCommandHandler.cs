using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.ProductHandlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IRepository<Product> _productRepository;

        public UpdateProductCommandHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

       

        async Task IRequestHandler<UpdateProductCommand>.Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            
            if (product == null)
            {
                throw new Exception("Ürün bulunamadı.");
            }

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.Stock = request.Stock;
            product.Images = request.Images;
            product.UpdatedAt = DateTime.Now;
            product.CategoryId = request.CategoryId;
            product.DolapURL = request.DolapURL;
            product.ShoppierURL = request.ShoppierURL;

            await _productRepository.UpdateAsync(product);
        }
    }
}
using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.Commands.CategoryCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand>
    {
        private readonly IRepository<Category> _categoryRepository;

        public RemoveCategoryCommandHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        async Task IRequestHandler<RemoveCategoryCommand>.Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
            
            if (category == null)
            {
                throw new Exception("Kategori bulunamadı.");
            }

            await _categoryRepository.RemoveAsync(category);
        }
    }
}
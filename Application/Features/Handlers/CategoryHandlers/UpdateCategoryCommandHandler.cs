using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.Commands.CategoryCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IRepository<Category> _categoryRepository;

        public UpdateCategoryCommandHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        async Task IRequestHandler<UpdateCategoryCommand>.Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
            
            if (category == null)
            {
                throw new Exception("Kategori bulunamadı.");
            }

            category.Name = request.Name;
            category.Image = request.Image;
            await _categoryRepository.UpdateAsync(category);
        }
    }
}
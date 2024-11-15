using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Application.Interfaces;
using Application.Features.Queries.CategoryQuery;
using Application.Features.Results.CategoryResults;
using Domain.Entities;

namespace Application.Features.Handlers.CategoryHandlers
{
    public class ResultCategoryByIdQueryHandler : IRequestHandler<CategoryQueryById, CategoryQueryByIdResult>
    {
        private readonly IRepository<Category> _categoryRepository;

        public ResultCategoryByIdQueryHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryQueryByIdResult> Handle(CategoryQueryById request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            
            if (category == null)
            {
                throw new Exception("Kategori bulunamadı.");
            }

            return new CategoryQueryByIdResult
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Image =category.Image
            };
        }
    }
}
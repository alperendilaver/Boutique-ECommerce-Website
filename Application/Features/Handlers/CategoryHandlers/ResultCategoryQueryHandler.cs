using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.CategoryQuery;
using Application.Features.Results.CategoryResults;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Handlers.CategoryHandlers
{
    public class ResultCategoryQueryHandler : IRequestHandler<CategoryQuery, List<CategoryQueryResult>>
    {
        private readonly IRepository<Category> _categoryRepository;

        public ResultCategoryQueryHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryQueryResult>> Handle(CategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();

            return categories.Select(category => new CategoryQueryResult
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Image = category.Image
            }).ToList();
        }
    }
}
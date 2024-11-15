using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Queries.ProductQuery;
using Application.Features.Results.ProductResults;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Handlers.ProductHandlers
{
    public class GetUserFavoritesProductQueryHandler : IRequestHandler<GetUserFavorites, List<GetUserFavoritesQueryResults>>
    {
        public IProductRepository _repository;
        public GetUserFavoritesProductQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetUserFavoritesQueryResults>> Handle(GetUserFavorites request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetUserFavorites(request.UserId);
            return products.Select(x=>new GetUserFavoritesQueryResults{
                CategoryId = x.CategoryId,
                Description = x.Description,
                Id = x.Id,
                Images= x.Images,
                Name = x.Name,
                Price = x.Price,
            }).ToList();
        }
    }
}
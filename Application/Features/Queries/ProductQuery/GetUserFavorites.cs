using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.ProductResults;
using MediatR;

namespace Application.Features.Queries.ProductQuery
{
    public class GetUserFavorites : IRequest<List<GetUserFavoritesQueryResults>>
    {
        public GetUserFavorites(string userId)
        {
            UserId = userId;
        }
        public string UserId { get; set; }
    }
}
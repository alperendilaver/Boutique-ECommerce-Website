using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.CategoryResults;
using Application.Features.Results.ProductResults;
using MediatR;

namespace Application.Features.Queries.CategoryQuery
{
    public class CategoryQuery : IRequest<List<CategoryQueryResult>>
    {
    }
}
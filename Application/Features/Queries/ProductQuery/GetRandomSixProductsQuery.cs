using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.ProductResults;
using MediatR;

namespace Application.Features.Queries.ProductQuery
{
    public class GetRandomSixProductsQuery:IRequest<List<ProductQueryResult>>
    {
        
    }
}
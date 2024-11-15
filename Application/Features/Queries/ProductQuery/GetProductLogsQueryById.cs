using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.ProductResults;
using MediatR;

namespace Application.Features.Queries.ProductQuery
{
    public class GetProductLogsQueryById:IRequest<List<GetProductLogsQueryByIdQueryResult>>
    {
        public GetProductLogsQueryById(int productId)
        {
            ProductId = productId;
        }
        public int ProductId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.ProductResults;
using MediatR;

namespace Application.Features.Queries.ProductQuery
    {
    public class ProductByNameQuery:IRequest<List<ProductFilterNameQueryResult>>
    {
        public ProductByNameQuery(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
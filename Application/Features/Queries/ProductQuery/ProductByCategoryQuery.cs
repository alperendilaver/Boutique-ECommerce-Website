using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.ProductResults;
using MediatR;

namespace Application.Features.Queries.ProductQuery
{
    public class ProductByCategoryQuery:IRequest<List<ProductFilterCategoryQueryResult>>
    {
        public ProductByCategoryQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
        public int CategoryId { get; set; }
    }

}
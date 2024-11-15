using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Results.ProductResults;
using MediatR;

namespace Application.Features.Queries.ProductQuery
{
    public class ProductQueryById : IRequest<ProductQueryByIdResult>
    {
        private const int MinimumId = 1;

        public ProductQueryById(int id)
        {
            if (id < MinimumId)
            {
                throw new ArgumentException($"Id {MinimumId}'den küçük olamaz.", nameof(id));
            }

            Id = id;
        }
        public int Id { get; set; }
    }
}
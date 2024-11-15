using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.Commands
{
    public class RemoveFavoriteProduct:IRequest
    {
        public int ProductId { get; set; }
        public string UserId { get; set; }
    }
}
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.Commands
{
    public class RemoveProductCommand : IRequest
    {
        public int Id { get; set; }
    }
}
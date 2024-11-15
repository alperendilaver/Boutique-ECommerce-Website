using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.Commands
{
    public class LogProductRouteCommand : IRequest
    {
        public int ProductId { get; set; }
        public bool IsDolap { get; set; }
    }
}
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.Commands.CategoryCommands
{
    public class RemoveCategoryCommand : IRequest
    {
       public int CategoryId { get; set;}
    }
}
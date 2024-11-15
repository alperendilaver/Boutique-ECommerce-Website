using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.Commands.CategoryCommands
{
    public class CreateCategoryCommand : IRequest
    {

        public string Name { get; set;}
        public string Image { get; set; }
    }
}
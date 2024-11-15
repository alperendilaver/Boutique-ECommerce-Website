using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.Commands.CategoryCommands
{
    public class UpdateCategoryCommand : MediatR.IRequest
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
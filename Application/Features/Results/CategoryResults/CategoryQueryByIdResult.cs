using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Results.CategoryResults
{
    public class CategoryQueryByIdResult
    {
       public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
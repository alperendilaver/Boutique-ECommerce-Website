using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set;}
        public string Name { get; set;}
        public List<Product> Products { get; set; }
        public string Image { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductRouteLog
    {
        [Key]
        public int LogId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDolap { get; set; }
    }
}
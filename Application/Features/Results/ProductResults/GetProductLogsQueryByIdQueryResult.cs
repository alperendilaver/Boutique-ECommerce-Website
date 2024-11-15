using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.Results.ProductResults
{
    public class GetProductLogsQueryByIdQueryResult
    {
         
        public int LogId { get; set; }
        public int ProductId { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDolap { get; set; }
    }
}
using SwiftMartAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftMartAPI.Domain.Entities
{
    public class ProductCategory:EntityBase
    {
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
        public Product? Product { get; set; }
        public int ProductId { get; set; }
    }
}

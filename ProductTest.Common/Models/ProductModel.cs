using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTest.Common.Models
{
    public class ProductModel
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public Guid CategoryId { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public bool Active { get; set; }

        public CategoryModel Category { get; set; }
    }
}

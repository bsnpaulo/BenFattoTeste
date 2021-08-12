using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.BenFatto.Domain.Entities
{
    public class Order
    {

        public int Id { get; set; }
        public int OrderNumber { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}

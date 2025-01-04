using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.DA.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}

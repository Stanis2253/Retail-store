using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.DA.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }
        public List<Category> Category { get; set; }
    }
}

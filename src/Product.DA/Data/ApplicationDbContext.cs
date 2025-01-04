using Microsoft.EntityFrameworkCore;
using Product.DA.Models;

namespace Product.DA.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Product.DA.Models.Product> Product { get; set; }
        public DbSet<Product.DA.Models.Category> Category { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Products.DA.Models;

namespace Products.DA.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}

using Identity.DA.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.DA.Data
{
    public class ApplicationDbContex : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContex(DbContextOptions<ApplicationDbContex> options) 
            : base(options) 
        {
            Database.EnsureCreated();
        }
    }
}

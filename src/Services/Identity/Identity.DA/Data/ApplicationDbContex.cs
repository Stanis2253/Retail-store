using Identity.DA.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

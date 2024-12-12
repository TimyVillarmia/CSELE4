using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CSELE4_MVC.Models;

namespace CSELE4_MVC.Data
{
    public class CSELE4_MVCContext : DbContext
    {
        public CSELE4_MVCContext (DbContextOptions<CSELE4_MVCContext> options)
            : base(options)
        {
        }

        public DbSet<CSELE4_MVC.Models.Products> Products { get; set; } = default!;
    }
}

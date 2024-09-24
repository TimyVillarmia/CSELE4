using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CSELE4_Activity.Model;

namespace CSELE4_Activity.Data
{
    public class CSELE4_ActivityContext : DbContext
    {
        public CSELE4_ActivityContext (DbContextOptions<CSELE4_ActivityContext> options)
            : base(options)
        {
        }

        public DbSet<CSELE4_Activity.Model.Product> Product { get; set; } = default!;
    }
}

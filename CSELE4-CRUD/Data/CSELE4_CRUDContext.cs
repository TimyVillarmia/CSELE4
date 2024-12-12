using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CSELE4_CRUD.Models;

namespace CSELE4_CRUD.Data
{
    public class CSELE4_CRUDContext : DbContext
    {
        public CSELE4_CRUDContext (DbContextOptions<CSELE4_CRUDContext> options)
            : base(options)
        {
        }

        public DbSet<CSELE4_CRUD.Models.Product> Product { get; set; } = default!;

        public DbSet<CSELE4_CRUD.Models.ProductCategory> Category { get; set; } = default!;
    }
}

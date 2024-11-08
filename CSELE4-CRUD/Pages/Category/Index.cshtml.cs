using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CSELE4_CRUD.Data;
using CSELE4_CRUD.Models;

namespace CSELE4_CRUD.Pages.Category
{
    public class IndexModel : PageModel
    {
        private readonly CSELE4_CRUD.Data.CSELE4_CRUDContext _context;

        public IndexModel(CSELE4_CRUD.Data.CSELE4_CRUDContext context)
        {
            _context = context;
        }

        public IList<ProductCategory> ProductCategory { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Category != null)
            {
                ProductCategory = await _context.Category.ToListAsync();
            }
        }
    }
}

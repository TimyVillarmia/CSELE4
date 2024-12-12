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
    public class DetailsModel : PageModel
    {
        private readonly CSELE4_CRUD.Data.CSELE4_CRUDContext _context;

        public DetailsModel(CSELE4_CRUD.Data.CSELE4_CRUDContext context)
        {
            _context = context;
        }

      public ProductCategory ProductCategory { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Category == null)
            {
                return NotFound();
            }

            var productcategory = await _context.Category.FirstOrDefaultAsync(m => m.CategoryID == id);
            if (productcategory == null)
            {
                return NotFound();
            }
            else 
            {
                ProductCategory = productcategory;
            }
            return Page();
        }
    }
}

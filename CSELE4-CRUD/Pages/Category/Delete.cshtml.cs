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
    public class DeleteModel : PageModel
    {
        private readonly CSELE4_CRUD.Data.CSELE4_CRUDContext _context;

        public DeleteModel(CSELE4_CRUD.Data.CSELE4_CRUDContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Category == null)
            {
                return NotFound();
            }
            var productcategory = await _context.Category.FindAsync(id);

            if (productcategory != null)
            {
                ProductCategory = productcategory;
                _context.Category.Remove(ProductCategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

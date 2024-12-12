using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CSELE4_CRUD.Data;
using CSELE4_CRUD.Models;

namespace CSELE4_CRUD.Pages.Category
{
    public class CreateModel : PageModel
    {
        private readonly CSELE4_CRUD.Data.CSELE4_CRUDContext _context;

        public CreateModel(CSELE4_CRUD.Data.CSELE4_CRUDContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ProductCategory ProductCategory { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Category == null || ProductCategory == null)
            {
                return Page();
            }

            _context.Category.Add(ProductCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

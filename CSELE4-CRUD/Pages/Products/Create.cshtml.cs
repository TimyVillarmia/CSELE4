using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CSELE4_CRUD.Data;
using CSELE4_CRUD.Models;
using CSELE4_Activity.Services;

namespace CSELE4_CRUD.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly CSELE4_CRUD.Data.CSELE4_CRUDContext _context;
        private readonly IFormFileService _formFileService;

        public CreateModel(CSELE4_CRUD.Data.CSELE4_CRUDContext context, IFormFileService formFileService)
        {
            _context = context;
            _formFileService = formFileService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(IFormFile productImage)
        {
          if (!ModelState.IsValid || _context.Product == null || Product == null)
          {
                return Page();
          }

            try
            {
                var new_product = new Product
                {
                    Name = Product.Name,
                    Description = Product.Description,
                    Category = Product.Category,
                    Price = Product.Price,
                    Content = _formFileService.ConvertToByteArray(productImage)
                };

                _context.Product.Add(new_product);
                await _context.SaveChangesAsync();
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("File", ex.Message);

            }




            return RedirectToPage("./Index");
        }
    }
}

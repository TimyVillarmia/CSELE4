using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSELE4_CRUD.Data;
using CSELE4_CRUD.Models;
using CSELE4_Activity.Services;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CSELE4_CRUD.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly CSELE4_CRUD.Data.CSELE4_CRUDContext _context;
        private readonly IFormFileService _formFileService;

        public EditModel(CSELE4_CRUD.Data.CSELE4_CRUDContext context, IFormFileService formFileService)
        {
            _context = context;
            _formFileService = formFileService;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        [BindProperty]
        public byte[]? PrevProductImage { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product =  await _context.Product.FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            Product = product;
            PrevProductImage = product.Content;
            //ProductImage = product.Content == null ? string.Empty : $"data:image;base64,{Convert.ToBase64String(product.Content)}";
           
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(IFormFile? productImage)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {

                if (productImage != null)
                {
                    Product.Content = _formFileService.ConvertToByteArray(productImage);

                }
                else
                {
                    Product.Content = PrevProductImage;
                }

                _context.Attach(Product).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductExists(int id)
        {
          return (_context.Product?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

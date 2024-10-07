using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CSELE4_Activity.Data;
using CSELE4_Activity.Model;
using Microsoft.EntityFrameworkCore;
using System.IO.Compression;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace CSELE4_Activity.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly CSELE4_Activity.Data.CSELE4_ActivityContext _context;

        public CreateModel(CSELE4_Activity.Data.CSELE4_ActivityContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ProductViewModel Product { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            using (var memoryStream = new MemoryStream())
            {
                await Product.FormFile.CopyToAsync(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {
                    
                    var new_product = new Product
                    {
                        Name = Product.Name,
                        Description = Product.Description,
                        Category = Product.Category,
                        Price = Product.Price,
                        Content = memoryStream.ToArray()
                    };

                    _context.Product.Add(new_product);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    ModelState.AddModelError("File", "The file is too large.");
                }
            }
  
            return RedirectToPage("./Index");

        }

    }
}

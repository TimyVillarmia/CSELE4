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
using CSELE4_Activity.Services;
using System.IO;

namespace CSELE4_Activity.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly CSELE4_Activity.Data.CSELE4_ActivityContext _context;
        private readonly IFormFileService _formFileService;

        public CreateModel(CSELE4_Activity.Data.CSELE4_ActivityContext context, IFormFileService formFileService)
        {
            _context = context;
            _formFileService = formFileService;
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
       
            try
            {
                var new_product = new Product
                {
                    Name = Product.Name,
                    Description = Product.Description,
                    Category = Product.Category,
                    Price = Product.Price,
                    Content = _formFileService.ConvertToByteArray(Product.FormFile)
                };

                _context.Product.Add(new_product);
                await _context.SaveChangesAsync();
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("File", ex.Message);

            }


            return RedirectToPage("../Index");

        }

    }
}

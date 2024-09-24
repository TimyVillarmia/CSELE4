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
using CSELE4_Activity.Services;
using Microsoft.Extensions.Hosting;

namespace CSELE4_Activity.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly CSELE4_Activity.Data.CSELE4_ActivityContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateModel(CSELE4_Activity.Data.CSELE4_ActivityContext context, IWebHostEnvironment webHostEnvironment, IFileUploadService fileUploadService)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _fileUploadService = fileUploadService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;
        public IFileUploadService _fileUploadService { get; }

        public string FilePath;
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            // The ImageName property will always be null, resulting in a model validation error being registered.
            // So the first thing you need to do is to remove any model state entries relating to this property
            // before you check Modelstate.IsValid.
            ModelState.Remove("Product.ProductImageFile");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _fileUploadService.UploadFileAsync(Product.ProductImage);
            Product.ProductImageFile = Product.ProductImage.FileName;


            _context.Product.Add(Product);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

        }

    }
}

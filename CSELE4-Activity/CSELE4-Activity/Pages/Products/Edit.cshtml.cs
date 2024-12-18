﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSELE4_Activity.Data;
using CSELE4_Activity.Model;
using System.IO;
using CSELE4_Activity.Services;

namespace CSELE4_Activity.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly CSELE4_Activity.Data.CSELE4_ActivityContext _context;
        private readonly IFormFileService _formFileService;

        public EditModel(CSELE4_Activity.Data.CSELE4_ActivityContext context, IFormFileService formFileService)
        {
            _context = context;
            _formFileService = formFileService;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;
        public ProductViewModel ProductVM { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product =  await _context.Product.FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
    

            Product = product;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Product).State = EntityState.Modified;

            try
            {
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

            return RedirectToPage("../Index");

        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}

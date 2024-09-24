using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CSELE4_Activity.Data;
using CSELE4_Activity.Model;

namespace CSELE4_Activity.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly CSELE4_Activity.Data.CSELE4_ActivityContext _context;

        public IndexModel(CSELE4_Activity.Data.CSELE4_ActivityContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await _context.Product.ToListAsync();
        }
    }
}

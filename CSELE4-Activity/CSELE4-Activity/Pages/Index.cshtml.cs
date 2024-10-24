using CSELE4_Activity.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CSELE4_Activity.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly CSELE4_Activity.Data.CSELE4_ActivityContext _context;


        public IndexModel(ILogger<IndexModel> logger, CSELE4_Activity.Data.CSELE4_ActivityContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IList<Product> Product { get; set; } = default!;
        public async Task OnGetAsync()
        {
            Product = await _context.Product.ToListAsync();
            
        }
    }
}

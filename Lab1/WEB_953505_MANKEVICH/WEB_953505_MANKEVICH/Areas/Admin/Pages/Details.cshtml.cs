using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEB_953505_MANKEVICH.Data;
using WEB_953505_MANKEVICH.Entities;

namespace WEB_953505_MANKEVICH.Areas.Admin.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Car = await _context.Cars
                .Include(c => c.Group).FirstOrDefaultAsync(m => m.CarId == id);

            if (Car == null) return NotFound();
            return Page();
        }
    }
}
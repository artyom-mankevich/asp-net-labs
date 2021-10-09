using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly WEB_953505_MANKEVICH.Data.ApplicationDbContext _context;

        public DetailsModel(WEB_953505_MANKEVICH.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Cars
                .Include(c => c.Group).FirstOrDefaultAsync(m => m.CarId == id);

            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

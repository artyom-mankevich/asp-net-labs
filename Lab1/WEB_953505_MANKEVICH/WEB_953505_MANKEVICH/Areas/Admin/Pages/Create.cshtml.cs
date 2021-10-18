using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEB_953505_MANKEVICH.Data;
using WEB_953505_MANKEVICH.Entities;

namespace WEB_953505_MANKEVICH.Areas.Admin.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public CreateModel(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        [BindProperty] public Car Car { get; set; }
        [BindProperty] public IFormFile Image { get; set; }

        public IActionResult OnGet()
        {
            ViewData["CarGroupId"] = new SelectList(_context.CarGroups, "CarGroupId", "GroupName");
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _context.Cars.Add(Car);
            await _context.SaveChangesAsync();

            if (Image != null)
            {
                var fileName = $"{Car.CarId}" + Path.GetExtension(Image.FileName);
                Car.Image = fileName;
                var path = Path.Combine(_environment.WebRootPath, "images",
                    fileName);
                await using (var fStream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(fStream);
                }

                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
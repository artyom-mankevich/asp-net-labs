using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WEB_953505_MANKEVICH.Data;
using WEB_953505_MANKEVICH.Entities;
using WEB_953505_MANKEVICH.Extensions;
using WEB_953505_MANKEVICH.Models;

namespace WEB_953505_MANKEVICH.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly int _pageSize;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
            _pageSize = 3;
            SetupData();
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo:int}")]
        public IActionResult Index(int? group, int pageNo = 1)
        {
            var carsFiltered = _context.Cars.Where(d =>
                !group.HasValue || d.CarGroupId == group.Value);
            ViewData["Groups"] = _context.CarGroups;
            ViewData["CurrentGroup"] = group ?? 0;

            var model = ListViewModel<Car>.GetModel(carsFiltered, pageNo,
                _pageSize);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_listpartial", model);
            }

            return View(model);
        }

        private void SetupData()
        {
        }
    }
}
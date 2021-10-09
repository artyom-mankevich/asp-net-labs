using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private ILogger _logger; 

        public ProductController(ApplicationDbContext context, ILogger<ProductController> logger)
        {
            _context = context;
            _logger = logger;
            _pageSize = 3;
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo:int}")]
        public IActionResult Index(int? group, int pageNo = 1)
        {
            _logger.LogInformation($"info: group={group}, page={pageNo}");
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
    }
}
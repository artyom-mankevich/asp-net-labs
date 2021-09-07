using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using WEB_953505_MANKEVICH.Models;

namespace WEB_953505_MANKEVICH.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            IEnumerable<ListDemo> list = new List<ListDemo>
            {
                new ListDemo { ListItemText = "item 1", ListItemValue = 1},
                new ListDemo { ListItemText = "item 2", ListItemValue = 2}
            };
            ViewBag.demoList = new SelectList(list, "ListItemValue", "ListItemText");
            ViewData["lab2text"] = "Лабораторная работа №2";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}
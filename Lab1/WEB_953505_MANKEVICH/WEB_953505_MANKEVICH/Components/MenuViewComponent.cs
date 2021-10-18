using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WEB_953505_MANKEVICH.Models;

namespace WEB_953505_MANKEVICH.Components
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly List<MenuItem> _menuItems = new()
        {
            new() {Controller = "Home", Action = "Index", Text = "Lab 2"},
            new() {Controller = "Product", Action = "Index", Text = "Каталог"},
            new() {IsPage = true, Area = "Admin", Page = "/Index", Text = "Администрирование"}
        };

        public IViewComponentResult Invoke()
        {
            var controller = ViewContext.RouteData.Values["controller"];
            var page = ViewContext.RouteData.Values["page"];
            var area = ViewContext.RouteData.Values["area"];

            foreach (var item in _menuItems)
            {
                var matchController = controller?.Equals(item.Controller) ?? false;
                var matchArea = area?.Equals(item.Area) ?? false;

                if (matchController || matchArea) item.Active = "active";
            }

            return View(_menuItems);
        }
    }
}
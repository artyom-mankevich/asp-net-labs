using Microsoft.AspNetCore.Mvc;

namespace WEB_953505_MANKEVICH.Components
{
    public class CartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WEB_953505_MANKEVICH.Data;
using WEB_953505_MANKEVICH.Extensions;
using WEB_953505_MANKEVICH.Models;

namespace WEB_953505_MANKEVICH.Controllers
{
    public class CartController : Controller
    {
        private Cart _cart;
        private readonly ApplicationDbContext _context;
        private readonly string cartKey = "cart";

        public CartController(ApplicationDbContext context, Cart cart)
        {
            _context = context;
            _cart = cart;
        }

        public IActionResult Index()
        {
            _cart = HttpContext.Session.Get<Cart>(cartKey);
            return View(_cart.Items.Values);
        }

        [Authorize]
        public IActionResult Add(int id, string returnUrl)
        {
            _cart = HttpContext.Session.Get<Cart>(cartKey);

            var item = _context.Cars.Find(id);
            if (item != null)
            {
                _cart.AddToCart(item);
                HttpContext.Session.Set(cartKey, _cart);
            }

            return Redirect(returnUrl);
        }

        public IActionResult Delete(int id, string returnUrl)
        {
            _cart = HttpContext.Session.Get<Cart>(cartKey);

            var item = _context.Cars.Find(id);
            if (item != null)
            {
                _cart.RemoveFromCart(id);
                HttpContext.Session.Set(cartKey, _cart);
            }

            return Redirect(returnUrl);
        }
    }
}
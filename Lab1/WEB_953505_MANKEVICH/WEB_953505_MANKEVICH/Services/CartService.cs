using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using WEB_953505_MANKEVICH.Entities;
using WEB_953505_MANKEVICH.Extensions;
using WEB_953505_MANKEVICH.Models;

namespace WEB_953505_MANKEVICH.Services
{
    public class CartService : Cart
    {
        private readonly string sessionKey = "cart";

        [JsonIgnore] private ISession Session { get; set; }

        public static Cart GetCart(IServiceProvider sp)
        {
            var session = sp
                .GetRequiredService<IHttpContextAccessor>()
                .HttpContext?.Session;
            var cart = session?.Get<CartService>("cart")
                       ?? new CartService();
            cart.Session = session;
            return cart;
        }

        public override void AddToCart(Car car)
        {
            base.AddToCart(car);
            Session?.Set(sessionKey, this);
        }

        public override void RemoveFromCart(int id)
        {
            base.RemoveFromCart(id);
            Session?.Set(sessionKey, this);
        }

        public override void ClearAll()
        {
            base.ClearAll();
            Session?.Set(sessionKey, this);
        }
    }
}
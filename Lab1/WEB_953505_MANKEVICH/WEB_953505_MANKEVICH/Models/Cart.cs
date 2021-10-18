using System.Collections.Generic;
using System.Linq;
using WEB_953505_MANKEVICH.Entities;

namespace WEB_953505_MANKEVICH.Models
{
    public class Cart
    {
        public Cart()
        {
            Items = new Dictionary<int, CartItem>();
        }

        public Dictionary<int, CartItem> Items { get; set; }

        public virtual int Count
        {
            get { return Items.Sum(item => item.Value.Quantity); }
        }


        public virtual void AddToCart(Car car)
        {
            if (Items.ContainsKey(car.CarId))
                Items[car.CarId].Quantity++;
            else
                Items.Add(car.CarId, new CartItem
                {
                    Car = car, Quantity = 1
                });
        }

        public virtual void RemoveFromCart(int id)
        {
            Items.Remove(id);
        }

        public virtual void ClearAll()
        {
            Items.Clear();
        }
    }
}
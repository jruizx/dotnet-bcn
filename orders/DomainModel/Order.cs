using System;

namespace orders
{
    public class Order : Entity
    {
        public int Amount { get; private set; }
        public DateTime Created { get; private set; }
        public Product Product { get; private set; }

        public static Order Create(Product product, int amount)
        {
            var order = new Order
            {
                Amount = amount,
                Product = product,
                Created = DateTime.Now
            };

            return order;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;


namespace orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IOrderContext context;

        public OrderRepository(IOrderContext context)
        {
            this.context = context;
        }

        public void Add(Order order)
        {
            this.context.Orders.InsertOne(order);
        }

        public IEnumerable<Order> GetAll()
        {
            return this.context.Orders.Find(x => true).ToList();
        }
    }
}
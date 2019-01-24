using System.Collections.Generic;
using System.Linq;
using orders;

namespace orders
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        void Add(Order order);
    }
}
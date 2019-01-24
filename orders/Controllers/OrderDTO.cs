using System;

namespace orders
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public int Amount { get; set; }
        public Guid ProductId {get; set; }
        public string ProductName { get; set; }
    }
}
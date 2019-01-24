using MongoDB.Driver;

namespace orders
{
    public interface IOrderContext 
    {
        IMongoCollection<Order> Orders { get; }
    }
}
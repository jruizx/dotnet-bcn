using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace orders
{
    public class OrderContext : IOrderContext
    {
        private readonly IMongoDatabase database;

        public OrderContext(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("default"));
            database = client.GetDatabase("OrdersDB");
        }

        public IMongoCollection<Order> Orders => database.GetCollection<Order>("Orders");
    }
}
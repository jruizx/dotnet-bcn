using System;
using MongoDB.Bson.Serialization;

namespace orders
{
    public static class Maps
    {
        public static void EntityMap()
        {
            BsonClassMap.RegisterClassMap<Entity>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(x => x.Id);
            });
        }

        public static void OrderMap()
        {
            BsonClassMap.RegisterClassMap<Order>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapMember(x => x.Amount).SetIsRequired(true);
            });
        }

        public static void ProductMap()
        {
            BsonClassMap.RegisterClassMap<Product>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapMember(x => x.Name).SetIsRequired(true);
            });
        }

        public static void MapAll()
        {
            Maps.EntityMap();
            Maps.OrderMap();
            Maps.ProductMap();
        }
    }
}
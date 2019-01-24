using System;

namespace orders
{
    public class Product : Entity
    {
        public string Name { get; private set; }

        public static Product Create(Guid id, string name)
        {
            var product = new Product
            {
                Id = id,
                Name = name
            };

            return product;
        }
    }
}
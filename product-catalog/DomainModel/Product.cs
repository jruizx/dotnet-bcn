namespace product_catalog
{
    public class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }

        protected Product()
        {
        }

        public static Product Create(string name, string description, string image)
        {
            var product = new Product
            {
                Name = name,
                Description = description,
                Image = image
            };

            return product;
        }
    }
}
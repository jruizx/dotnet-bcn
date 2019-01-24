using System;
using System.Linq;

namespace product_catalog
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductCatalogContext context;

        public ProductRepository(ProductCatalogContext context)
        {
            this.context = context;
        }

        public void Add(Product product)
        {
            this.context.Add(product);
        }

        public IQueryable<Product> GetAll()
        {
            return this.context.Products;
        }
    }
}
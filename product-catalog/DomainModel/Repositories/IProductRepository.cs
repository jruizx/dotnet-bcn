using System;
using System.Linq;

namespace product_catalog
{
    public interface IProductRepository
    {
        IQueryable<Product> GetAll();
        void Add(Product product);
    }
}
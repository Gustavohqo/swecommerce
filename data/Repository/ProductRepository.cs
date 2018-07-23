using System.Collections.Generic;
using System.Linq;
using model;

namespace data
{
    public class ProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public IList<Product> FindAll()
        {
            return _context.Set<Product>().ToList();
        }

        public Product Add(Product product)
        {
            _context.Set<Product>().Add(product);
            return product;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
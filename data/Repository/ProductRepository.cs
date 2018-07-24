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
        
        public Product FindById(long id)
        {
            var contextProduct = _context.Set<Product>();
            return contextProduct.Find(id);
        }

        public Product Add(Product product)
        {
            _context.Set<Product>().Add(product);
            return product;
        }

        public void Remove(long id)
        {
            var contextProduct = _context.Set<Product>();
            Product product = contextProduct.Find(id);
            contextProduct.Remove(product);
        }

        public Product Update(Product update, long id)
        {
            if (update == null)
                return null;
            
            var contextProduct = _context.Set<Product>();
            var actual = contextProduct.Find(id);
            
            if (actual != null)
            {
                _context.Entry(actual).CurrentValues.SetValues(update);
            }

            return actual;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using model;

namespace data
{
    public class PromotionRepository
    {
        private readonly Context _context;

        public PromotionRepository(Context context)
        {
            _context = context;
        }

        public IList<Promotion> FindAll()
        {
            return _context.Set<Promotion>().ToList();
        }

        public Promotion FindById(long? id)
        {
            return _context.Set<Promotion>().Find(id);
        }

        public Promotion Add(Promotion product)
        {
            _context.Set<Promotion>().Add(product);
            return product;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
using System.Collections.Generic;
using data;
using model;

namespace service
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IList<Product> findAll()
        {
            return _productRepository.FindAll();
        }

        public Product save(Product product)
        {
            _productRepository.Add(product);
            _productRepository.Save();

            return product;
        }
    }
}
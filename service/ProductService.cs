using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using data;
using model;

namespace service
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;
        private readonly PromotionService _promotionService;

        public ProductService(ProductRepository productRepository,
            PromotionService promotionService)
        {
            _productRepository = productRepository;
            _promotionService = promotionService;
        }

        public IList<Product> FindAll()
        {
            return _productRepository.FindAll();
        }

        public Product FindById(long id)
        {
            return _productRepository.FindById(id);
        }

        public Product Update(Product newProduct, long oldId)
        {
            var product = _productRepository.Update(newProduct, oldId);
            _productRepository.Save();

            return product;
        }

        public void Delete(long id)
        {
            _productRepository.Remove(id);
            _productRepository.Save();
        }

        public Product Save(Product product)
        {
            if (product.PromotionID != null && _promotionService.FindById(product.PromotionID) == null)
                throw new ValidationException("There is no Promotion with given id")
                {
                    Source = "promotionID"
                };
                
            _productRepository.Add(product);
            _productRepository.Save();

            return product;
        }
    }
}
using System.Collections.Generic;
using model;
using Microsoft.AspNetCore.Mvc;
using service;
using webapi.Validator;


namespace webapi.Controllers
{    
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        /*
         * GET: /product
         *
         * Gets the list of Products already registered at the store
         */
        [HttpGet]
        public IList<Product> Get()
        {
            return _productService.findAll();
        }

        /*
         * POST: /product
         *
         * saves a product into the store
         */
        [HttpPost]
        [ValidateModel]
        public OkObjectResult save([FromBody] Product productModel)
        {
            return Ok(_productService.save(productModel));
        }
    }
}
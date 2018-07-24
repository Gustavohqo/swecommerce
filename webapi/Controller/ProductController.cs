using System;
using System.ComponentModel.DataAnnotations;
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
        public IActionResult GetAll()
        {
            return Ok(_productService.FindAll());
        }
        
        /*
         * GET: /product/:id
         *
         * Gets a product by its id.
         */
        [HttpGet("{productId}")]
        public IActionResult GetById(long id)
        {
            return Ok(_productService.FindById(id));
        }
        
        /*
         * POST: /product
         *
         * saves a product into the store
         */
        [HttpPost]
        [ValidateModel]
        public IActionResult Save([FromBody] Product productModel)
        {
            try
            {
                return Ok(_productService.Save(productModel));
            }
            catch (ValidationException e)
            {
                ModelState.AddModelError(e.Source, e.Message);
                return BadRequest(ModelState);
            }
        }
        
        /*
         * PUT: /product/:id
         *
         * Update a product that is already on the store
         */
        [HttpPut("{productId}")]
        public IActionResult Update(long productId, [FromBody] Product newProduct)
        {
            return Ok(_productService.Update(newProduct, productId));
        }
        
        /*
         * DELETE: /product/:id
         *
         * Remove a product from store
         */
        [HttpDelete("{productId}")]
        public IActionResult Remove(long productid)
        {
            _productService.Delete(productid);
            return Ok();
        }
    }
}
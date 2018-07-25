using System;
using System.ComponentModel.DataAnnotations;
using model;
using Microsoft.AspNetCore.Mvc;
using service;

namespace webapi.Controllers
{
    [Route("/api/cart")]
    public class CartController : Controller
    {
        private CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_cartService.GetCart());
        }

        [HttpPut]
        public IActionResult AddItem([FromBody] CartItem cartItem)
        {
            try
            {
                return Ok(_cartService.UpdateItem(cartItem));
            }
            catch (ValidationException e)
            {
                ModelState.AddModelError(e.Source, e.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
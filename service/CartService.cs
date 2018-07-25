using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Castle.Core.Internal;
using model;

namespace service
{
    public class CartService
    {
        private readonly ProductService _productService;
        private readonly PromotionService _promotionService;

        private static Cart _cart = new Cart()
        {
            products = new Dictionary<long, CartItem>(),
            grossValue = 0,
            netValue = 0,
            totalDiscount = 0
        };

        public CartService(ProductService productService,
            PromotionService promotionService)
        {
            _promotionService = promotionService;
            _productService = productService;
        }

        public Cart GetCart()
        {
            return _cart;
        }

        /**
         * Updates an Item on the cart. 
         */
        public Cart UpdateItem(CartItem cartItem)
        {
            ValidateCarItem(cartItem);

            if (_cart.products.ContainsKey(cartItem.ProductID))
            {
                var actual = new CartItem();
                _cart.products.TryGetValue(cartItem.ProductID, out actual);
                
                ValidateAmount(cartItem.Amount);
                actual.Amount = cartItem.Amount;
            }
            else
            {
                _cart.products.Add(cartItem.ProductID, cartItem);
            }

            RemoveItems();
            CalculateValues();
            return _cart;
        }

        /**
         * Remove from cart all items that has Amount equal to 0. 
         */
        private void RemoveItems()
        {
            var products = _cart.products.Values;

            foreach (var product in products)
            {
                if (product.Amount == 0)
                    _cart.products.Remove(product.ProductID);
            }
        }

        /*
         * Calculate the actual values that compose the Cart. 
         */
        private void CalculateValues()
        {
            var items = _cart.products.Values;

            clearValues();
            if (items.IsNullOrEmpty())
                return;

            foreach (var item in items)
            {
                var product = _productService.FindById(item.ProductID);
                _cart.grossValue += product.price * item.Amount;

                if (product.PromotionID != null)
                {
                    var promotion = _promotionService.FindById(product.PromotionID);
                    _cart.netValue += promotion.totalValue(product.price, item.Amount);
                }

                _cart.totalDiscount = _cart.grossValue - _cart.netValue;
            }
        }

        private void clearValues()
        {
            _cart.grossValue = 0;
            _cart.netValue = 0;
            _cart.totalDiscount = 0;
        }

        #region Validations

        /*
         * Validates if an Item is already on DB.
         * In case it is not a ValidationException is thrown.
         */
        private void ValidateCarItem(CartItem cartItem)
        {
            if (_productService.FindById(cartItem.ProductID) == null)
            {
                throw new ValidationException("Item with id " + cartItem.ProductID + "not found.")
                {
                    Source = "productID"
                };
            }
        }
        
        /*
         * Validates if a given amount is positive.
         * In case it is negative a ValidationException is thrown.
         */
        private void ValidateAmount(int newAmount)
        {
            if (newAmount < 0)
            {
                throw new ValidationException("Item with id {carItem.ProductID} has invalid amount")
                {
                    Source = "amount"
                };
            }
        }
        
        #endregion
    }
}
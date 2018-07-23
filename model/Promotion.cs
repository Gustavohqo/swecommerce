using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace model
{
    public class Promotion
    {
        public long ID { get; set; }
        
        [Required]
        public string name { get; set; }

        [Range(0,int.MaxValue)]
        public decimal value { get; set; }

        [Range(0,int.MaxValue)]
        public int clause { get; set; }

        public PromotioType ValueType { get; set; }

        public decimal totalValue(decimal price, int amount)
        {
            return ValueType.Equals(PromotioType.FIXED) ? totalValueFixed(price, amount) : totalValuePercentage(price, amount);
        }
        
        private decimal totalValueFixed(decimal price, int amount)
        {
            if (clause == 0)
            {
                return amount * value;
            }

            var discount = amount / clause;
            var realValue = amount % clause;
            
            return discount*value + realValue*price;
        }
        
        private decimal totalValuePercentage(decimal price, int amount)
        {
            var valuePerItem = (1 - (value / 100)) * price;
            
            if (clause == 0)
            {
                return amount * valuePerItem;
            }
            
            var discount = amount / clause;
            var realValue = amount % clause;
            
            return discount*valuePerItem + realValue*price;
        }
    }
}
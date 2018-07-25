using System;
using System.ComponentModel.DataAnnotations;

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

        [EnumDataType(typeof(PromotioType))]
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
            if (clause == 0)
                return (amount * price) * (1 - (value / 100));
            
            var realValue = amount % clause;
            var toBeDiscounted = amount - realValue;
            
            return ((value / 100)) * (price*toBeDiscounted) + realValue*price;
        }
    }
}
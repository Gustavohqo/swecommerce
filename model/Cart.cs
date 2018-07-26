using System.Collections.Generic;

namespace model
{
    public class Cart
    {
        public virtual Dictionary<long, CartItem> products { get; set; }

        public decimal grossValue { get; set; }
        
        public decimal netValue { get; set; }
        
        public decimal totalDiscount { get; set; }
    }
}
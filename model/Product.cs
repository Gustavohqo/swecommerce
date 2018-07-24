using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace model
{
    public class Product
    {
        public long ID { get; set; }
        
        [Required]
        public string name { get; set; }
        
        [Range(0.001, int.MaxValue)]
        public decimal price { get; set; }

        public long? PromotionID { get; set; }
    }
}
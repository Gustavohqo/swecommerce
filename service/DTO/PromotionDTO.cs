using System.ComponentModel.DataAnnotations;

namespace service.DTO
{
    public class PromotionDTO
    {
        [Required] public int ID { get; set; }

        [Required] public string Name { get; set; }
    }
}
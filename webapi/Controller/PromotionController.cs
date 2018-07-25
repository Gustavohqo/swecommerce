using model;
using Microsoft.AspNetCore.Mvc;
using service;
using webapi.Validator;

namespace webapi.Controllers
{
    [Route("api/promotion")]
    public class PromotionController : Controller
    {
        private PromotionService _promotionService;

        public PromotionController(PromotionService promotionService)
        {
            _promotionService = promotionService;
        }
        
        [HttpGet]
        public IActionResult getAll()
        {
            return Ok(_promotionService.FindAll());
        }
        
        [HttpPost]
        [ValidateModel]
        public IActionResult create([FromBody] Promotion promotionModel)
        {
            return Ok(_promotionService.Save(promotionModel));
        }
    }
}
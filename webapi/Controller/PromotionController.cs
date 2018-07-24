using System.Collections.Generic;
using model;
using Microsoft.AspNetCore.Mvc;
using service;
using service.DTO;
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
        public IList<PromotionDTO> getAll()
        {
            return _promotionService.FindAll();
        }
        
        [HttpPost]
        [ValidateModel]
        public PromotionDTO create([FromBody] Promotion promotion)
        {
            return _promotionService.Save(promotion);
        }
    }
}
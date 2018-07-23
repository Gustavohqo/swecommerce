using System.Collections.Generic;
using data;
using model;
using service.DTO;
using AutoMapper;


namespace service
{
    public class PromotionService
    {
        private readonly PromotionRepository _promotionRepository;

        public PromotionService(PromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }

        public IList<PromotionDTO> findAll()
        {
            return Mapper.Map<IList<PromotionDTO>>(_promotionRepository.FindAll());
        }

        public PromotionDTO save(Promotion promotion)
        {
            _promotionRepository.Add(promotion);
            _promotionRepository.Save();

            return Mapper.Map<PromotionDTO>(promotion);
        }
    }
}
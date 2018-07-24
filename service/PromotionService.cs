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

        public IList<PromotionDTO> FindAll()
        {
            return Mapper.Map<IList<PromotionDTO>>(_promotionRepository.FindAll());
        }

        public Promotion FindById(long? id)
        {
            return _promotionRepository.FindById(id);
        }

        public PromotionDTO Save(Promotion promotion)
        {
            _promotionRepository.Add(promotion);
            _promotionRepository.Save();

            return Mapper.Map<PromotionDTO>(promotion);
        }
    }
}
using AutoMapper;
using model;
using service.DTO;

namespace service.Mappers
{
    public class EntityMapperProfile : Profile
    {
        public EntityMapperProfile()
        {
            CreateMap<Promotion, PromotionDTO>();
        }
    }
}
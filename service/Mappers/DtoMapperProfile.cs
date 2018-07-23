using AutoMapper;
using model;
using service.DTO;

namespace service.Mappers
{
    public class DtoMapperProfile : Profile
    {
        public DtoMapperProfile()
        {
            CreateMap<PromotionDTO, Promotion>()
                .ForMember(m => m.ID, map => map.MapFrom(vm => vm.ID))
                .ForMember(m => m.name, map => map.MapFrom(vm => vm.Name))
                .ForAllOtherMembers(m=> m.Ignore());
        }
    }
}
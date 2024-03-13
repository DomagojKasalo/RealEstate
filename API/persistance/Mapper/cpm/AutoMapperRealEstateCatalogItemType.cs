using AutoMapper;
using domain.Dto.realestate;
using domain.Entities.releastate;

namespace xtend_platform_persistance.Mapper.CPM
{
    public class AutoMapperRealEstateCatalogItemType : Profile
    {
        public AutoMapperRealEstateCatalogItemType()
        {
            CreateMap<CatalogItemType, CatalogItemTypeDto>().ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                                                            .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                                                            .ForMember(d => d.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate))
                                                            .ForMember(d => d.CreatedUser, opt => opt.MapFrom(s => s.CreatedUser))
                                                            .ForMember(d => d.ModifiedDate, opt => opt.MapFrom(s => s.ModifiedDate))
                                                            .ForMember(d => d.ModifiedUser, opt => opt.MapFrom(s => s.ModifiedUser));

            CreateMap<CatalogItemTypeDto, CatalogItemType>().ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                                                            .ForMember(d => d.CreatedUser, opt => opt.MapFrom(s => s.CreatedUser))
                                                            .ForMember(d => d.ModifiedUser, opt => opt.MapFrom(s => s.ModifiedUser));
        }
    }
}

using AutoMapper;
using domain.Dto.relestate;
using domain.Entities.releastate;

namespace persistance.Mapper.CPM
{
    public class AutoMapperRealEstateCatalog : Profile
    {
        public AutoMapperRealEstateCatalog()
        {
            CreateMap<Catalog, RealEstateCatalogDto>().ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                                                      .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                                                      .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                                                      .ForMember(d => d.CompanyId, opt => opt.MapFrom(s => s.CompanyId))
                                                      .ForMember(d => d.CatalogTypeId, opt => opt.MapFrom(s => s.CatalogTypeId))
                                                      .ForMember(d => d.CatalogTypeName, opt => opt.MapFrom(s => s.CatalogType.Name))
                                                      .ForPath(d => d.CompanyName, opt => opt.MapFrom(s => s.Company.CompanyName))
                                                      .ForMember(d => d.IsEnabled, opt => opt.MapFrom(s => s.IsEnabled))
                                                      .ForMember(d => d.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate))
                                                      .ForMember(d => d.CreatedUser, opt => opt.MapFrom(s => s.CreatedUser))
                                                      .ForMember(d => d.ModifiedDate, opt => opt.MapFrom(s => s.ModifiedDate))
                                                      .ForMember(d => d.ModifiedUser, opt => opt.MapFrom(s => s.ModifiedUser));


            CreateMap<RealEstateCatalogDto, Catalog>().ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                                                      .ForMember(d => d.CompanyId, opt => opt.MapFrom(s => s.CompanyId))
                                                      .ForMember(d => d.CatalogTypeId, opt => opt.MapFrom(s => s.CatalogTypeId))
                                                      .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                                                      .ForMember(d => d.CreatedUser, opt => opt.MapFrom(s => s.CreatedUser))
                                                      .ForMember(d => d.ModifiedUser, opt => opt.MapFrom(s => s.ModifiedUser));
        }
    }
}

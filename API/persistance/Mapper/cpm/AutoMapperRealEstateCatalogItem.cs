using AutoMapper;
using domain.Dto.relestate;
using domain.Entities.releastate;

namespace xtend_platform_persistance.Mapper.CPM
{
    public class AutoMapperRealEstateCatalogItem : Profile
    {
        public AutoMapperRealEstateCatalogItem()
        {
            // read
            CreateMap<CatalogItem, RealEstateCatalogItemDto>().ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                                                              .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                                                              .ForPath(d => d.CompanyId, opt => opt.MapFrom(s => s.Catalog.CompanyId))
                                                              .ForPath(d => d.CompanyName, opt => opt.MapFrom(s => s.Catalog.Company.CompanyName))
                                                              .ForMember(d => d.VersionIdentifier, opt => opt.MapFrom(s => s.VersionIdentifier))
                                                              .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                                                              .ForMember(d => d.CatalogId, opt => opt.MapFrom(s => s.CatalogId))
                                                              .ForMember(d => d.CatalogItemStatusId, opt => opt.MapFrom(s => s.CatalogItemStatusId))
                                                              .ForMember(d => d.CatalogItemTypeId, opt => opt.MapFrom(s => s.CatalogItemTypeId))
                                                              .ForMember(d => d.CatalogItemTypeName, opt => opt.MapFrom(s => s.CatalogItemType.Name))
                                                              .ForPath(d => d.CatalogName, opt => opt.MapFrom(s => s.Catalog.Name))
                                                              .ForMember(d => d.Quote, opt => opt.MapFrom(s => s.Quote))

                                                              .ForMember(d => d.Floors, opt => opt.MapFrom(s => s.Floors))
                                                              .ForMember(d => d.Rooms, opt => opt.MapFrom(s => s.Rooms))
                                                              .ForMember(d => d.Bathrooms, opt => opt.MapFrom(s => s.Bathrooms))
                                                              .ForMember(d => d.GaragePlaces, opt => opt.MapFrom(s => s.GaragePlaces))
                                                              .ForMember(d => d.Lamella, opt => opt.MapFrom(s => s.Lamella))
                                                              .ForMember(d => d.Floor, opt => opt.MapFrom(s => s.Floor))
                                                              .ForMember(d => d.Units, opt => opt.MapFrom(s => s.Units))
                                                              .ForMember(d => d.Dimensions, opt => opt.MapFrom(s => s.Dimensions))
                                                              .ForMember(d => d.NetArea, opt => opt.MapFrom(s => s.NetArea))
                                                              .ForMember(d => d.BruttoArea, opt => opt.MapFrom(s => s.BruttoArea))
                                                              .ForMember(d => d.IsEnabled, opt => opt.MapFrom(s => s.IsEnabled))
                                                              .ForMember(d => d.IsFeatured, opt => opt.MapFrom(s => s.IsFeatured))
                                                              .ForMember(d => d.Disclaimer, opt => opt.MapFrom(s => s.Disclaimer))
                                                              .ForMember(d => d.IsDisclamer, opt => opt.MapFrom(s => s.IsDisclamer))
                                                              .ForMember(d => d.ApprovedUser, opt => opt.MapFrom(s => s.ApprovedUser))
                                                              .ForMember(d => d.DeploymentStatusId, opt => opt.MapFrom(s => s.DeploymentStatusId))

                                                              .ForMember(d => d.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate))
                                                              .ForMember(d => d.CreatedUser, opt => opt.MapFrom(s => s.CreatedUser))
                                                              .ForMember(d => d.ModifiedDate, opt => opt.MapFrom(s => s.ModifiedDate))
                                                              .ForMember(d => d.ModifiedUser, opt => opt.MapFrom(s => s.ModifiedUser));
            // Write
            CreateMap<RealEstateCatalogItemDto, CatalogItem>().ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                                                              .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                                                              .ForMember(d => d.Floors, opt => opt.MapFrom(s => s.Floors))
                                                              .ForMember(d => d.Rooms, opt => opt.MapFrom(s => s.Rooms))
                                                              .ForMember(d => d.Bathrooms, opt => opt.MapFrom(s => s.Bathrooms))
                                                              .ForMember(d => d.GaragePlaces, opt => opt.MapFrom(s => s.GaragePlaces))
                                                              .ForMember(d => d.Lamella, opt => opt.MapFrom(s => s.Lamella))
                                                              .ForMember(d => d.Floor, opt => opt.MapFrom(s => s.Floor))
                                                              .ForMember(d => d.Units, opt => opt.MapFrom(s => s.Units))
                                                              .ForMember(d => d.Dimensions, opt => opt.MapFrom(s => s.Dimensions))
                                                              .ForMember(d => d.NetArea, opt => opt.MapFrom(s => s.NetArea))
                                                              .ForMember(d => d.BruttoArea, opt => opt.MapFrom(s => s.BruttoArea))
                                                              .ForMember(d => d.IsEnabled, opt => opt.MapFrom(s => s.IsEnabled))
                                                              .ForMember(d => d.IsFeatured, opt => opt.MapFrom(s => s.IsFeatured))
                                                              .ForMember(d => d.CreatedUser, opt => opt.MapFrom(s => s.CreatedUser))
                                                              .ForMember(d => d.ModifiedUser, opt => opt.MapFrom(s => s.ModifiedUser))
                                                              .ForMember(d => d.CatalogId, opt => opt.MapFrom(s => s.CatalogId))
                                                              .ForMember(d => d.CatalogItemStatusId, opt => opt.MapFrom(s => s.CatalogItemStatusId))
                                                              .ForMember(d => d.CatalogItemTypeId, opt => opt.MapFrom(s => s.CatalogItemTypeId))
                                                              .ForMember(d => d.Disclaimer, opt => opt.MapFrom(s => s.Disclaimer))
                                                              .ForMember(d => d.ApprovedUser, opt => opt.MapFrom(s => s.ApprovedUser))
                                                              .ForMember(d => d.DeploymentStatusId, opt => opt.MapFrom(s => s.DeploymentStatusId));
        }
    }
}

using AutoMapper;
using domain.Dto.crm;
using domain.Entities.crm;

namespace persistance.Mapper.CRM
{
    public class AutoMapperCompany : Profile
    {
        public AutoMapperCompany()
        {
            CreateMap<Company, CompanyDto>().ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                                            .ForMember(d => d.CompanyTypeId, opt => opt.MapFrom(s => s.CompanyTypeId))
                                            .ForMember(d => d.CompanyName, opt => opt.MapFrom(s => s.CompanyName))
                                            .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                                            .ForMember(d => d.WebSite, opt => opt.MapFrom(s => s.WebSite))
                                            .ForMember(d => d.Phone, opt => opt.MapFrom(s => s.Phone))
                                            .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
                                            .ForMember(d => d.BillingAddress, opt => opt.MapFrom(s => s.BillingAddress))
                                            .ForMember(d => d.ShipingAddress, opt => opt.MapFrom(s => s.ShipingAddress))
                                            .ForMember(d => d.BillingZip, opt => opt.MapFrom(s => s.BillingZip))
                                            .ForMember(d => d.ShipingZip, opt => opt.MapFrom(s => s.ShipingZip))
                                            .ForMember(d => d.RegistrationDate, opt => opt.MapFrom(s => s.RegistrationDate))
                                            .ForMember(d => d.GID, opt => opt.MapFrom(s => s.GID))
                                            .ForMember(d => d.GVAT, opt => opt.MapFrom(s => s.GVAT))
                                            .ForPath(d => d.CompanyTypeName, opt => opt.MapFrom(s => s.CompanyType.Name))
                                            .ForMember(d => d.CompanyAcronym, opt => opt.MapFrom(s => s.CompanyAcronym))
                                            .ForMember(d => d.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate))
                                            .ForMember(d => d.ModifiedDate, opt => opt.MapFrom(s => s.ModifiedDate))
                                            .ForMember(d => d.CreatedUser, opt => opt.MapFrom(s => s.CreatedUser))
                                            .ForMember(d => d.ModifiedUser, opt => opt.MapFrom(s => s.ModifiedUser));

            CreateMap<CompanyDto, Company>().ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                                            .ForMember(d => d.CompanyTypeId, opt => opt.MapFrom(s => s.CompanyTypeId))
                                            .ForMember(d => d.CompanyName, opt => opt.MapFrom(s => s.CompanyName))
                                            .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                                            .ForMember(d => d.WebSite, opt => opt.MapFrom(s => s.WebSite))
                                            .ForMember(d => d.Phone, opt => opt.MapFrom(s => s.Phone))
                                            .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
                                            .ForMember(d => d.BillingAddress, opt => opt.MapFrom(s => s.BillingAddress))
                                            .ForMember(d => d.ShipingAddress, opt => opt.MapFrom(s => s.ShipingAddress))
                                            .ForMember(d => d.BillingZip, opt => opt.MapFrom(s => s.BillingZip))
                                            .ForMember(d => d.ShipingZip, opt => opt.MapFrom(s => s.ShipingZip))
                                            .ForMember(d => d.RegistrationDate, opt => opt.MapFrom(s => s.RegistrationDate))
                                            .ForMember(d => d.CompanyAcronym, opt => opt.MapFrom(s => s.CompanyAcronym))
                                            .ForMember(d => d.GID, opt => opt.MapFrom(s => s.GID))
                                            .ForMember(d => d.GVAT, opt => opt.MapFrom(s => s.GVAT))
                                            .ForMember(d => d.CreatedUser, opt => opt.MapFrom(s => s.CreatedUser))
                                            .ForMember(d => d.ModifiedUser, opt => opt.MapFrom(s => s.ModifiedUser));

            CreateMap<Company, CompanyLightDto>().ForMember(d => d.CompanyName, opt => opt.MapFrom(s => s.CompanyName))
                                                 .ForMember(d => d.WebSite, opt => opt.MapFrom(s => s.WebSite))
                                                 .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
                                                 .ForPath(d => d.CompanyType, opt => opt.MapFrom(s => s.CompanyType.Name));
        }
    }
}

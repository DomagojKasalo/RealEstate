using AutoMapper;
using domain.Dto.crm;
using domain.Entities.crm;

namespace persistance.Mapper.CRM
{
    public class AutoMapperCompanyType : Profile
    {
        public AutoMapperCompanyType()
        {
            CreateMap<CompanyType, CompanyTypeDto>().ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                                                    .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                                                    .ForMember(d => d.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate))
                                                    .ForMember(d => d.ModifiedDate, opt => opt.MapFrom(s => s.ModifiedDate))
                                                    .ForMember(d => d.CreatedUser, opt => opt.MapFrom(s => s.CreatedUser))
                                                    .ForMember(d => d.ModifiedUser, opt => opt.MapFrom(s => s.ModifiedUser));

            CreateMap<CompanyTypeDto, CompanyType>().ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                                                    .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                                                    .ForMember(d => d.CreatedUser, opt => opt.MapFrom(s => s.CreatedUser))
                                                    .ForMember(d => d.ModifiedUser, opt => opt.MapFrom(s => s.ModifiedUser));
        }
    }
}

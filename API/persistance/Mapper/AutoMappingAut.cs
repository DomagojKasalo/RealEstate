using AutoMapper;
using domain.Dto.users;
using domain.Entities.users;

namespace persistance.Mapper
{
    public class AutoMappingAut : Profile
    {
        public AutoMappingAut()
        {

            CreateMap<User, UserDto>().ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                                      .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName))
                                      .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName))
                                      .ForMember(d => d.PhoneNumber, opt => opt.MapFrom(s => s.PhoneNumber))
                                      .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.Email))
                                      .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
                                      .ForMember(d => d.Address, opt => opt.MapFrom(s => s.Address))
                                      .ForMember(d => d.CompanyId, opt => opt.MapFrom(s => s.CompanyId))
                                      .ForPath(d => d.CompanyName, opt => opt.MapFrom(s => s.Company.CompanyName))
                                      .ForMember(d => d.Roles, opt => opt.Ignore())
                                      .ReverseMap();

            CreateMap<UserDto, User>()
                                      .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName))
                                      .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName))
                                      .ForMember(d => d.Address, opt => opt.MapFrom(s => s.Address))
                                      .ForMember(d => d.PhoneNumber, opt => opt.MapFrom(s => s.PhoneNumber))
                                      .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.Email))
                                      .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
                                      .ForMember(d => d.CompanyId, opt => opt.MapFrom(s => s.CompanyId));
        }
           
    }
}

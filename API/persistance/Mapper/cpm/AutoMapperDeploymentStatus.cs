using AutoMapper;
using domain.Dto.realestate;
using domain.Dto.relestate;
using domain.Entities.releastate;

namespace persistance.Mapper.CPM
{
    public class AutoMapperDeploymentStatus : Profile
    {
        public AutoMapperDeploymentStatus()
        {
            CreateMap<DeploymentStatus, DeploymentStatusDto>().ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                                                              .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))

                                                              .ForMember(d => d.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate))
                                                              .ForMember(d => d.CreatedUser, opt => opt.MapFrom(s => s.CreatedUser))
                                                              .ForMember(d => d.ModifiedDate, opt => opt.MapFrom(s => s.ModifiedDate))
                                                              .ForMember(d => d.ModifiedUser, opt => opt.MapFrom(s => s.ModifiedUser));

            CreateMap<DeploymentStatusDto, DeploymentStatus>().ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))

                                                              .ForMember(d => d.CreatedUser, opt => opt.MapFrom(s => s.CreatedUser))
                                                              .ForMember(d => d.ModifiedUser, opt => opt.MapFrom(s => s.ModifiedUser));
        }
    }
}

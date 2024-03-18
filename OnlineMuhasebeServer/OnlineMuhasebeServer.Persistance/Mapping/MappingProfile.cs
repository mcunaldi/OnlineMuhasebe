using AutoMapper;
using OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Command.CreateCompany;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFetures.Commands.CreateRole;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Command.CreateUCAF;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.Persistance.Mapping;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCompanyRequest, Company>();
        CreateMap<CreateUCAFRequest, UniformChartOfAccount>();
        CreateMap<CreateRoleRequest, AppRole>();
    }
}

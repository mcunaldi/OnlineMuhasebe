using AutoMapper;
using OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Command.CreateCompany;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Command.CreateUCAF;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.Persistance.Mapping;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCompanyRequest, Company>().ReverseMap();
        CreateMap<CreateUCAFRequest, UniformChartOfAccount>().ReverseMap();
    }
}

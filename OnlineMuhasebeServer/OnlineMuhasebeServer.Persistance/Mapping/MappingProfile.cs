using AutoMapper;
using OnlineMuhasebeServer.Application.Features.AppFeatures.Company.CompanyFeatures.Command.CreateCompany;
using OnlineMuhasebeServer.Domain.AppEntities;

namespace OnlineMuhasebeServer.Persistance.Mapping;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCompanyRequest, Company>().ReverseMap();
    }
}

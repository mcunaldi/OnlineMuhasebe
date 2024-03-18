using OnlineMuhasebeServer.Application.Services.AppService;
using OnlineMuhasebeServer.Application.Services.CompanyService;
using OnlineMuhasebeServer.Domain;
using OnlineMuhasebeServer.Domain.Repositories.UCAFRepositories;
using OnlineMuhasebeServer.Persistance;
using OnlineMuhasebeServer.Persistance.Repositories.UCAFRepositories;
using OnlineMuhasebeServer.Persistance.Services.AppServices;
using OnlineMuhasebeServer.Persistance.Services.CompanyServices;

namespace OnlineMuhasebeServer.WebAPI.Configurations;

public class PersistanceDIServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        #region Context UnitOfWork
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        #endregion

        #region Services
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<IContextService, ContextService>();
        services.AddScoped<IUCAFService, UCAFService>();
        #endregion

        #region Repositories
        services.AddScoped<IUCAFCommandRepository, UCAFCommandRepository>();
        services.AddScoped<IUCAFQueryRepository, UCAFQueryRepository>();
        #endregion
    }
}


using OnlineMuhasebeServer.Application;

namespace OnlineMuhasebeServer.WebAPI.Configurations;

public class ApplicationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly);
        });


    }
}

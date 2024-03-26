
using FluentValidation;
using MediatR;
using OnlineMuhasebeServer.Application;
using OnlineMuhasebeServer.Application.Behavior;

namespace OnlineMuhasebeServer.WebAPI.Configurations;

public class ApplicationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly);
        });

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddValidatorsFromAssembly(typeof(AssemblyReference).Assembly);
    }
}

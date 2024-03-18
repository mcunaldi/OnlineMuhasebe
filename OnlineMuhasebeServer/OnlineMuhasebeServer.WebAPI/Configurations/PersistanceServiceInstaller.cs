
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using OnlineMuhasebeServer.Persistance;
using OnlineMuhasebeServer.Persistance.Context;

namespace OnlineMuhasebeServer.WebAPI.Configurations;

public class PersistanceServiceInstaller : IServiceInstaller
{
    private const string SectionName = "SqlServer";
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });

        services.AddIdentity<AppUser, AppRole>()
            .AddEntityFrameworkStores<AppDbContext>();


        services.AddAutoMapper(typeof
            (AssemblyReference).Assembly);
    }
}

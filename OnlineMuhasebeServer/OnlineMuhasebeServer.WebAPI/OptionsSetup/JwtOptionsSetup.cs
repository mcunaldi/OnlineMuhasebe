using Microsoft.Extensions.Options;
using OnlineMuhasebeServer.Infrastructure.Authentication;

namespace OnlineMuhasebeServer.WebAPI.OptionsSetup;

public sealed class JwtOptionsSetup(IConfiguration configuration) : IConfigureOptions<JwtOptions>
{
    public void Configure(JwtOptions options)
    {
        configuration.GetSection("Jwt").Bind(options);
    }
}

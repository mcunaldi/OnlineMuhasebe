using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineMuhasebeServer.Application.Abstractions;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace OnlineMuhasebeServer.Infrastructure.Authentication;
public sealed class JwtProvider(
    IOptions<JwtOptions> jwtOptions,
    UserManager<AppUser> userManager) : IJwtProvider
{
    public async Task<string> CreateTokenAsync(AppUser user, List<string> roles)
    {
        var claims = new Claim[]
        {
            new Claim(JwtRegisteredClaimNames.Sub,user.FirstNameLastName),
            new Claim(JwtRegisteredClaimNames.Email,user.Email),
            new Claim(ClaimTypes.Authentication, user.Id),
            new Claim(ClaimTypes.Role, string.Join(",", roles))
        };

        DateTime expires = DateTime.Now.AddDays(1);

        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
            issuer: jwtOptions.Value.Issuer,
            audience: jwtOptions.Value.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: expires,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Value.SecretKey)), SecurityAlgorithms.HmacSha256));

        string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        string refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
        user.RefreshToken = refreshToken;
        user.RefreshTokenExpires = expires.AddDays(1);

        await userManager.UpdateAsync(user);

        return token;
    }
}

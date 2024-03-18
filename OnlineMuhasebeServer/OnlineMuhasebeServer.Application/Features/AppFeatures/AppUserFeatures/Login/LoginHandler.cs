using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Abstractions;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.AppUserFeatures.Login;
public class LoginHandler(
    IJwtProvider jwtProvider,
    UserManager<AppUser> userManager) : IRequestHandler<LoginRequest, LoginResponse>
{
    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        AppUser user = await userManager
            .Users
            .Where(p =>
            p.UserName == request.EmailOrUserName ||
            p.Email == request.EmailOrUserName).FirstOrDefaultAsync();
        if (user == null)
        {
            throw new Exception("Kullanıcı bulunamadı!");
        }

        var checkUser = await userManager.CheckPasswordAsync(user, request.Password);
        if (!checkUser)
        {
            throw new Exception("Parola yanlış!");
        }

        List<string> roles = new();

        LoginResponse response = new()
        {
            Email = user.Email,
            FirstNameLastName = user.FirstNameLastName,
            UserId = user.Id,
            Token = await jwtProvider.CreateTokenAsync(user, roles)
        };

        return response;
    }
}

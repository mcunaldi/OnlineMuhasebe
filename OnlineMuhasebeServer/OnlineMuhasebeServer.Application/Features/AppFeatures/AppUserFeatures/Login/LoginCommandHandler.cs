using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Abstractions;
using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.AppUserFeatures.Login;
public class LoginCommandHandler(
    IJwtProvider jwtProvider,
    UserManager<AppUser> userManager) : ICommandHandler<LoginCommand, LoginCommandResponse>
{
    public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
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

        LoginCommandResponse response = new(
            user.Email,
            user.FirstNameLastName,
            user.Id,
            await jwtProvider.CreateTokenAsync(user, roles));

        return response;
    }
}

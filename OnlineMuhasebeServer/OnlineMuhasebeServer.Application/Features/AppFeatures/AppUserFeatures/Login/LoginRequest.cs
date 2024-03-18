using MediatR;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.AppUserFeatures.Login;
public sealed record LoginRequest(
    string EmailOrUserName,
    string Password) : IRequest<LoginResponse>;

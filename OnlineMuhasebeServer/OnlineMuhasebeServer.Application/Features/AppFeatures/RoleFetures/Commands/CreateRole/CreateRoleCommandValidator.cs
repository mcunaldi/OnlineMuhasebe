using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFetures.Commands.CreateRole;
public sealed class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(p => p.Code).NotEmpty().NotEmpty().WithMessage("Role kodu boş olamaz");
        RuleFor(p => p.Name).NotEmpty().NotEmpty().WithMessage("Role adı boş olamaz");
    }
}

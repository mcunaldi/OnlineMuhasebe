using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFetures.Commands.UpdateRole;
public sealed class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
{
    public UpdateRoleCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty().NotNull().WithMessage("ID bilgisi boş olamaz");
        RuleFor(p => p.Code).NotEmpty().NotEmpty().WithMessage("Role kodu boş olamaz");
        RuleFor(p => p.Name).NotEmpty().NotEmpty().WithMessage("Role adı boş olamaz");
    }
}

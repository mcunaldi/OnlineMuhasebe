using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFetures.Commands.DeleteRole;
public class DeleteRoleCommandValidator : AbstractValidator<DeleteRoleCommand>
{
    public DeleteRoleCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty().NotNull().WithMessage("ID bilgisi boş olamaz");
    }
}

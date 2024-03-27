using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Command.CreateCompany;
public sealed class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
{
    public CreateCompanyCommandValidator()
    {
        RuleFor(p=> p.DatabaseName).NotEmpty().NotNull().WithMessage("Database bilgisi yazılmalıdır!");
        RuleFor(p=> p.ServerName).NotEmpty().NotNull().WithMessage("Server bilgisi yazılmalıdır!");
        RuleFor(p=> p.Name).NotEmpty().NotNull().WithMessage("Şirket adı yazılmalıdır!");
    }
}

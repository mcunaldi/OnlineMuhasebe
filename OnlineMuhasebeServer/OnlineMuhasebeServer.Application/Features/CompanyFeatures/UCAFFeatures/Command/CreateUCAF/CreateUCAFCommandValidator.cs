using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Command.CreateUCAF;
public sealed class CreateUCAFCommandValidator : AbstractValidator<CreateUCAFCommand>
{
    public CreateUCAFCommandValidator()
    {
        RuleFor(p => p.Code).NotEmpty().NotEmpty().WithMessage("Role kodu boş olamaz");
        RuleFor(p => p.Name).NotEmpty().NotEmpty().WithMessage("Role adı boş olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().NotEmpty().WithMessage("Şirket bilgisi boş olamaz");
        RuleFor(p => p.Type).NotEmpty().NotEmpty().WithMessage("Hesap planı tipi boş olamaz");
        RuleFor(p => p.Type).MaximumLength(1).WithMessage("Hesap planı tipi 1 karakter olmalıdır");
        //RuleFor(p => p.Name).MinimumLength(4).WithMessage("Hesap planı kodu en az 4 karakter olmalıdır!");
    }
}

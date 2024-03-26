using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.AppUserFeatures.Login;
public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(p=> p.EmailOrUserName).NotEmpty().NotNull().WithMessage("Mail ya da kullanıcı adı yazmalısınız!");
        RuleFor(p=> p.Password).NotEmpty().NotNull().WithMessage("Şifre boş olamaz!");
        RuleFor(p=> p.Password).MinimumLength(6).WithMessage("Mail ya da kullanıcı adı yazmalısınız!");
        RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Şifreniz en az 1 büyük karakter içermelidir!");
        RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Şifreniz en az 1 küçük karakter içermelidir!");
        RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Şifreniz en az 1 sayı içermelidir!");
        RuleFor(p => p.Password).Matches("[^a-zA-Z0-9]").WithMessage("Şifreniz en az 1 özel karakter içermelidir!");
    }
}

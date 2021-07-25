using Arts.Entity.Dto.User;
using FluentValidation;

namespace Arts.Business.FluentValidation.User
{
    public class UserLoginValidation : AbstractValidator<UserLoginDto>
    {
        public UserLoginValidation()
        {
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("Email adresi gereklidir.")
                .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");
            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("Şifre boş bırakılamaz.");
        }
    }
}
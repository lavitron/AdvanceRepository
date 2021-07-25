using Arts.Entity.Dto.User;
using FluentValidation;

namespace Arts.Business.FluentValidation.User
{
    public class UserRegisterValidation : AbstractValidator<UserRegisterDto>
    {
        public UserRegisterValidation()
        {
            RuleFor(p => p.Name)
                .Length(3, 20).WithMessage("Lütfen geçerli bir isim giriniz.")
                .NotEmpty().WithMessage("İsim boş bırakılamaz.");
            RuleFor(p => p.Surname)
                .Length(3, 20).WithMessage("Lütfen geçerli bir soyisim giriniz.")
                .NotEmpty().WithMessage("Soyisim boş bırakılamaz.");
            RuleFor(p => p.Email)
                .EmailAddress().WithMessage("Lütfen geçerli mail adresi giriniz")
                .NotEmpty().WithMessage("Email boş bırakılamaz");
            RuleFor(p => p.Address)
                .Length(10, 200).WithMessage("Lütfen geçerli bir adres giriniz.")
                .NotEmpty().WithMessage("Adres boş bırakılamaz.");
            RuleFor(p => p.Phone)
                .Length(11, 11).WithMessage("Lütfen geçerli bir telefon numarası giriniz.")
                .NotEmpty().WithMessage("Telefon numarası boş bırakılamaz.");
            RuleFor(p => p.Password)
                .Length(5, 25).WithMessage("Şifreniz 5-25 karakterden oluşabilir.")
                .NotEmpty().WithMessage("Şifre boş bırakılamaz.");
            RuleFor(p => p.UserRole)
                .NotEmpty().WithMessage("Kullanıcı rolü ekleyiniz");
        }
    }
}
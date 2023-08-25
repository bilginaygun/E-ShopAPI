using E_ShopAPI.Entity.DTO.Login;
using FluentValidation;

namespace E_ShopAPI.Apı.Validation.FluentValidation
{
    public class LoginValidator : AbstractValidator<LoginRequestDTO>
    {
        public LoginValidator()
        {
            RuleFor(q => q.KullaniciAdi).NotEmpty().WithMessage("Kullanıcı Adı Boş Olamaz");
            RuleFor(q => q.Sifre).NotEmpty().WithMessage("Şifre Boş Olamaz");
        }
    }
}

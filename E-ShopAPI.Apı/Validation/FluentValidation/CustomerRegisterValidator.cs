using E_ShopAPI.Entity.DTO.Customer;
using FluentValidation;

namespace E_ShopAPI.Apı.Validation.FluentValidation
{
    public class CustomerRegisterValidator : AbstractValidator<CustomerDTORequest>
    {
        public CustomerRegisterValidator()
        {
            RuleFor(q => q.FirstName).NotEmpty().WithMessage("Ad Boş Olamaz");
            RuleFor(q => q.LastName).NotEmpty().WithMessage("Soyad Boş Olamaz");
            RuleFor(q => q.Customername).NotEmpty().WithMessage("Kullanıcı Adı Boş Olamaz");
            RuleFor(q => q.Password).NotEmpty().WithMessage("Şifre Boş Olamaz");
            RuleFor(q => q.Email).NotEmpty().WithMessage("E-Posta Boş Olamaz");
            RuleFor(q => q.PhoneNumber).NotEmpty().WithMessage("Telefon Numarası Boş Olamaz");
            RuleFor(q => q.Adress).NotEmpty().WithMessage("Adres Boş Olamaz");
        }
    }
}

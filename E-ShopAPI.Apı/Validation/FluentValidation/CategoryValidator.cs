using E_ShopAPI.Entity.DTO.Category;
using FluentValidation;

namespace E_ShopAPI.Apı.Validation.FluentValidation
{
    public class CategoryValidator : AbstractValidator<CategoryDTORequest>
    {
        public CategoryValidator()
        {
            RuleFor(q => q.Name).NotEmpty().WithMessage("Kategori Adı Boş Olamaz");
        }
    }
}

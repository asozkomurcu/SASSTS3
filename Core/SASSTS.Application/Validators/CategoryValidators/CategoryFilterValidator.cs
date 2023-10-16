using FluentValidation;
using SASSTS.Application.Models.RequestModels.CategoriesRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Validators.CategoryValidators
{
    public class CategoryFilterValidator : AbstractValidator<UpdateCategoryVM>
    {
        public CategoryFilterValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Kategori kimlik numarası boş brakılamaz.")
                .GreaterThan(0).WithMessage("Kategori kimlik numarası sıfırdan büyük olmalıdır.");

            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Kategori adı boş bırakılamaz.")
                .MaximumLength(50).WithMessage("Kategori adı en fazla 50 karakter olabilir.");
        }
    }
}

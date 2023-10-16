using FluentValidation;
using SASSTS.Application.Models.RequestModels.ProductsRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Validators.ProductValidators
{
    public class DeleteProductValidator : AbstractValidator<DeleteProductVM>
    {
        public DeleteProductValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Ürün kimlik numarası boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Ürün kimlik numarası sıfırdan büyük olmalıdır.");
        }
    }
}

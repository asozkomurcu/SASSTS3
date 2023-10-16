using FluentValidation;
using SASSTS.Application.Models.RequestModels.ProductsRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Validators.ProductValidators
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductVM>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Ürün kimlik numarası boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Ürün kimlik numarası sıfırdan büyük olmalıdır.");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Kategori kimlik numarası boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Kategori kimlik numarası sıfırdan büyük olmalıdır.");

            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Ürün adı boş bırakılamaz.")
                .MaximumLength(150).WithMessage("Ürün adı en fazla 150 karakter olabilir.");

            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Ürün adı boş bırakılamaz.")
                .MaximumLength(50).WithMessage("Ürün adı en fazla 50 karakter olabilir.");

            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("Ürün mikterı boş bırakılamaz.")
                .GreaterThanOrEqualTo(0).WithMessage("Ürün miktarı sıfır veya sıfırdan büyük olmalıdır.");

            RuleFor(x => x.UnitPrice)
                .NotEmpty().WithMessage("Ürün birim fiyatı boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Ürün birim fiyatı sıfırdan büyük olmalıdır.");
        }
    }
}

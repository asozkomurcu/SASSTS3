using FluentValidation;
using SASSTS.Application.Models.RequestModels.BillsRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Validators.BillValidators
{
    public class CreateBillValidator : AbstractValidator<CreateBillVM>
    {
        public CreateBillValidator()
        {
            RuleFor(x => x.WholesalerId)
                .NotEmpty().WithMessage("Tedarikçi kimlik numarası boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Tedarikçi kimlik numarası sıfırdan büyük olmalıdır.");

            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Ürün kimlik numarası boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Ürün kimlik numarası sıfırdan büyük olmalıdır.");

            RuleFor(x => x.BillDate)
                .NotEmpty().WithMessage("Fatura tarihi boş bırakılamaz.");

            RuleFor(x => x.BillNumber)
                .NotEmpty().WithMessage("Fatura numarası boş bırakılamaz.")
                .MinimumLength(16)
                .MaximumLength(16).WithMessage("Fatura numarası 16 karakter olmalıdır.");

            RuleFor(x => x.BillType)
                .NotEmpty().WithMessage("Fatura tipi boş bırakılamaz.")
                .MaximumLength(10).WithMessage("Fatura tipi en fazla 10 karakter olabilir.");

            RuleFor(x => x.WholesalerName)
                .NotEmpty().WithMessage("Tedarikçi adı boş bırakılamaz.")
                .MaximumLength(100).WithMessage("Tedarikçi adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Ürün adı boş bırakılamaz.")
                .MaximumLength(150).WithMessage("Ürün adı en fazla 150 karakter olabilir.");

            RuleFor(x => x.UnitPrice)
                .NotEmpty().WithMessage("Ürün birim fiyatı boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Ürün birim fiyatı sıfırdan büyük olmalıdır.");

            RuleFor(x => x.KDV)
                .NotEmpty().WithMessage("Ürün KDV oranı boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Ürün KDV oranı sıfırdan büyük olmalıdır.");

            RuleFor(x => x.Discount)
                .NotEmpty().WithMessage("Ürün indirim fiyatı boş bırakılamaz.")
                .GreaterThanOrEqualTo(0).WithMessage("Ürün indirim fiyatı sıfır veya sıfırdan büyük olmalıdır.");

            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("Ürün mikterı boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Ürün mikterı sıfırdan büyük olmalıdır.");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Ürün toplam fiyatı boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Ürün toplam fiyatı sıfırdan büyük olmalıdır.");

            RuleFor(x => x.TotalUnitPrice)
                .NotEmpty().WithMessage("Fatura birim fiyatı boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Fatura birim fiyatı sıfırdan büyük olmalıdır.");

            RuleFor(x => x.TotalDiscount)
                .NotEmpty().WithMessage("Fatura toplam indirim fiyatı boş bırakılamaz.")
                .GreaterThanOrEqualTo(0).WithMessage("Fatura toplam indirim fiyatı sıfır veya sıfırdan büyük olmalıdır.");

            RuleFor(x => x.TotalKDV)
                .NotEmpty().WithMessage("Fatura toplam KDV fiyatı boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Fatura toplam KDV fiyatı sıfırdan büyük olmalıdır.");

            RuleFor(x => x.TotalPrice)
                .NotEmpty().WithMessage("Fatura toplam fiyatı boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Fatura toplam fiyatı sıfırdan büyük olmalıdır.");
        }
    }
}

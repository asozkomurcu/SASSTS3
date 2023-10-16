using FluentValidation;
using SASSTS.Application.Models.RequestModels.PriceOffersRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Validators.PriceOfferValidators
{
    public class CreatePriceOfferValidator : AbstractValidator<CreatePriceOfferVM>
    {
        public CreatePriceOfferValidator()
        {
            RuleFor(x => x.PurchaseRequestId)
                .NotEmpty().WithMessage("Satın alım talebi kimlik numarası boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Satın alım talebi kimlik numarası sıfırdan büyük olmalıdır.");

            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("Kullanıcı kimlik numarası boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Kullanıcı kimlik numarası sıfırdan büyük olmalıdır.");

            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Ürün kimlik numarası boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Ürün kimlik numarası sıfırdan büyük olmalıdır.");

            RuleFor(x => x.WholesalerId)
                .NotEmpty().WithMessage("Tedarikçi kimlik numarası boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Tedarikçi kimlik numarası sıfırdan büyük olmalıdır.");

            RuleFor(x => x.CustomerName)
                .NotEmpty().WithMessage("Personel adı boş bırakılamaz.")
                .MaximumLength(50).WithMessage("Personel adı en fazla 50 karakter olabilir.");

            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Ürün adı boş bırakılamaz.")
                .MaximumLength(150).WithMessage("Ürün adı en fazla 150 karakter olabilir.");

            RuleFor(x => x.WholesalerName)
                .NotEmpty().WithMessage("Tedarikçi adı boş bırakılamaz.")
                .MaximumLength(100).WithMessage("Tedarikçi adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("Ürün mikterı boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Ürün mikterı sıfırdan büyük olmalıdır.");

            RuleFor(x => x.UnitPrice)
                .NotEmpty().WithMessage("Ürün birim fiyatı boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Ürün birim fiyatı sıfırdan büyük olmalıdır.");

            RuleFor(x => x.TotalPrice)
                .NotEmpty().WithMessage("Ürün toplam fiyatı boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Ürün toplam fiyatı sıfırdan büyük olmalıdır.");

            RuleFor(x => x.DeliveryDate)
                .NotEmpty().WithMessage("Tahmini teslimat tarihi boş bırakılamaz");

        }
    }
}

using FluentValidation;
using SASSTS.Application.Models.RequestModels.PurchaseRequestsRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Validators.PurchaseRequestValidators
{
    public class UpdatePurchaseRequestValidator : AbstractValidator<UpdatePurchaseRequestVM>
    {
        public UpdatePurchaseRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Satın alım talep kimlik numarası boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Satın alım talep kimlik numarası sıfırdan büyük olmalıdır.");

            //RuleFor(x => x.ProductId)
            //    .NotEmpty().WithMessage("Ürün kimlik numarası boş bırakılamaz.")
            //    .GreaterThan(0).WithMessage("Ürün kimlik numarası sıfırdan büyük olmalıdır.");

            //RuleFor(x => x.RequestCustomerId)
            //    .NotEmpty().WithMessage("Kullanıcı kimlik numarası boş bırakılamaz.")
            //    .GreaterThan(0).WithMessage("Kullanıcı kimlik numarası sıfırdan büyük olmalıdır.");

            //RuleFor(x => x.RequestCustomerName)
            //    .NotEmpty().WithMessage("Personel adı boş bırakılamaz.")
            //    .MaximumLength(50).WithMessage("Personel adı en fazla 50 karakter olabilir.");

            //RuleFor(x => x.OfferCustomerId)
            //    .GreaterThan(0).WithMessage("Kullanıcı kimlik numarası sıfırdan büyük olmalıdır.");

            //RuleFor(x => x.OfferCustomerName)
            //    .MaximumLength(50).WithMessage("Personel adı en fazla 50 karakter olabilir.");

            //RuleFor(x => x.ApprovingCustomerId)
            //    .GreaterThan(0).WithMessage("Kullanıcı kimlik numarası sıfırdan büyük olmalıdır.");

            //RuleFor(x => x.ApprovingCustomerName)
            //    .MaximumLength(50).WithMessage("Personel adı en fazla 50 karakter olabilir.");

            //RuleFor(x => x.ProductName)
            //    .NotEmpty().WithMessage("Ürün adı boş bırakılamaz.")
            //    .MaximumLength(150).WithMessage("Ürün adı en fazla 150 karakter olabilir.");

            //RuleFor(x => x.ProductDescription)
            //    .NotEmpty().WithMessage("Ürün açıklaması boş bırakılamaz.")
            //    .MaximumLength(500).WithMessage("Ürün açıklaması en fazla 500 karakter olabilir.");

            //RuleFor(x => x.Amount)
            //    .NotEmpty().WithMessage("Ürün mikterı boş bırakılamaz.")
            //    .GreaterThan(0).WithMessage("Ürün mikterı sıfırdan büyük olmalıdır.");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Ürün talep durumu boş bırakılamaz.")
                .IsInEnum();

            RuleFor(x => x.PriceOfferId)
                .GreaterThan(0).WithMessage("Fiyat teklifi kimlik numarası sıfırdan büyük olmalıdır.");

        }
    }
}
